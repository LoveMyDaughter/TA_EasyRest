# TA_EasyRest
RV-093.Net Team-1 Test Automation

## Easyrest deployment
Repo:
https://bitbucket.org/katemalash/easyrest/src/master/

If you deploy Easyrest on docker:
  - change local port 8880 to 3000 for frontend container in file "docker-compose.yml"
  - change "sqlalchemy.url" accordingly to the hint in "development.ini" file
