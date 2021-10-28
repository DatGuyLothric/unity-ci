const puppeteer = require('puppeteer');
const fs = require('fs');

async function start() {
    var browser;
    var page;
    var downloadPath;
    var client;
    var navigationPromise;

    await init();
    await login();
    await license();
    await selectType();
    await ulfFile();

    await browser.close()
}

async function init() {
    browser = await puppeteer.launch({
        args: ['--no-sandbox', '--disable-setuid-sandbox']
    });
    page = await browser.newPage();
    downloadPath = process.cwd();
    client = await page.target().createCDPSession();
    await client.send('Page.setDownloadBehavior', {
        behavior: 'allow',
        downloadPath: downloadPath
    });
    navigationPromise = page.waitForNavigation({
        waitUntil: 'domcontentloaded'
    });
}

async function login() {
    await page.goto('https://license.unity3d.com/manual');

    await Promise.all([
        await navigationPromise,
        await page.waitForSelector('#new_conversations_create_session_form #conversations_create_session_form_password')
    ]);
    
    const email = `${process.argv[3]}`;
    await page.type('input[type=email]', email);

    const password = `${process.argv[4]}`;
    await page.type('input[type=password]', password);
    await page.click('input[name="commit"]');

    await navigationPromise;
}

async function license() {
    const licenseFile = 'input[name="licenseFile"]';
    await page.waitFor(10000);

    const input = await page.$(licenseFile);
    
    const alfPath = `${process.argv[2]}`;
    await input.uploadFile(alfPath);
    
    await page.click('input[name="commit"]');

    await navigationPromise;
}

async function selectType() {
    const selectedTypePersonal = 'input[id="type_personal"][value="personal"]';
    await page.waitForSelector(selectedTypePersonal);
    await page.evaluate(
        s => document.querySelector(s).click(),
        selectedTypePersonal
    );

    const selectedPersonalCapacity = 'input[id="option3"][name="personal_capacity"]';
    await page.evaluate(
        s => document.querySelector(s).click(),
        selectedPersonalCapacity
    );

    await page.click('input[class="btn mb10"]');

    await Promise.all([
        await navigationPromise,
        await page.waitFor(1000)
    ]);
}

async function ulfFile() {
    await page.click('input[name="commit"]');

    let _ = await (async () => {
        let ulf;
        do {
            for (const file of fs.readdirSync(downloadPath)) {
                ulf |= file.endsWith('.ulf');
            }
            await sleep(1000);
        } while (!ulf);
    })();
}

function sleep(milliSeconds) {
    return new Promise((resolve, reject) => {
        setTimeout(resolve, milliSeconds)
    });
}

(async () => await start())();
