dotnet test --configuration Release --framework net5.0 /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=..\TestResults\Coverage\

dotnet reportgenerator "-reports:..\TestResults\Coverage\coverage.net5.0.cobertura.xml" "-targetdir:..\TestResults\Coverage\Reports" -reportTypes:HtmlInline_AzurePipelines;htmlInline