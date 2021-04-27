## DotNetCore.Zeebe.IntegrationTestTool (Is not maintained, and should therefor be considered deprecated)
A ASP.Net core application for ad-hoc integration  testing  against a Zeebe Cluster.

To use:
1. set the URL for the Zeebe cluster gateway in the configuration file under "ConnectionStrings".
2. set the URL for the Zeebe clustes ElasticSearch gateway in the configuration file under "ConnectionStrings".

All exceptions are handled by middleware. As per default developer exception pages are used in Development enviroment.

Zeebe Docs
https://zeebe.io/

