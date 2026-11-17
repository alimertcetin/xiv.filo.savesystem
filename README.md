# PACKAGE-NAME

## Npm Publish Checklist

1. [ ] Use this template
2. [ ] Set NPM_TOKEN
    1. Go to settings
    2. Select Actions under Secrets and Variables
    3. New repository secret
    4. Set name as "NPM_TOKEN" and set the Secret that you get from npm
3. [ ] Clone the repo to directly inside unity project
    - This will create .meta files
4. [ ] Create and checkout "Prepare-Npm" branch
5. [ ] Run "npm init" after checkout in the root directory of the repo
6. [ ] Edit packages.json with relative information about the package
    - Update "name"
    - Update "displayName"
    - Update "description"
    - Update "keywords" if necessary
    - Update "license"
    - ! Do not update the version !
7. [ ] Update docfx_project/api/index.md file
8. [ ] Update THIS README.md with the package details and documentation link
9. [ ] Create "Runtime" folder in the root of the repo
10. [ ] Create/Move the files inside the "Runtime" folder
11. [ ] Commit and push the changes
