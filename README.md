# Activating Unity
## Personal License
Get activation file for OSX hardware using activation workflow (run it manually and take the file from workflow artifacts).
Upload file to license.unity3d.com and get license file.
Paste content of license file to UNITY_LICENSE secret.

## Pro License
Add UNITY_SERIAL (your personal pro serial key you got from license purchase), UNITY_EMAIL and UNITY_PASSWORD (from account you use to login to Unity) secrets.
!Important: Do not forget to return your pro license after build workflow.
```yml
- name: Return license
  uses: game-ci/unity-return-license@v1
  if: always()
```
