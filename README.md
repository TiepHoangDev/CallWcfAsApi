# Config:
```
<system.serviceModel>
		<services>
			<service name="WcfServiceLibrary1.WCFService1">
				<host>
					<baseAddresses>
						<add baseAddress = "http://localhost:8734/WCFService1/" />
					</baseAddresses>
				</host>
				<!-- Service Endpoints -->
				<!-- Unless fully qualified, address is relative to base address supplied above -->
				<endpoint address="" binding="basicHttpBinding" contract="WcfServiceLibrary1.IWCFService1">
					<!-- 
              Upon deployment, the following identity element should be removed or replaced to reflect the 
              identity under which the deployed service runs.  If removed, WCF will infer an appropriate identity 
              automatically.
          -->
					<identity>
						<dns value="localhost"/>
					</identity>
				</endpoint>
				<endpoint address="http://localhost:8733/WCFService1/mex" binding="mexHttpBinding" contract="IMetadataExchange"  />
				<endpoint address="net.tcp://localhost:8080/Service1" binding="netTcpBinding" contract="WcfServiceLibrary1.IWCFService1" />

				<endpoint address="http://localhost:8734/WCFService1/Web/" binding="webHttpBinding" contract="WcfServiceLibrary1.IWCFService1" behaviorConfiguration="webBehaviorConfig" />

				<!-- Metadata Endpoints -->
				<!-- The Metadata Exchange endpoint is used by the service to describe itself to clients. -->
				<!-- This endpoint does not use a secure binding and should be secured or removed before deployment -->
				<endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange"/>


			</service>
		</services>
		<behaviors>
			<endpointBehaviors>
				<behavior name="webBehaviorConfig">
					<webHttp />
				</behavior>
			</endpointBehaviors>
			<serviceBehaviors>

				<behavior>
					<!-- To avoid disclosing metadata information, 
          set the values below to false before deployment -->
					<serviceMetadata httpGetEnabled="True" httpsGetEnabled="True"/>
					<!-- To receive exception details in faults for debugging purposes, 
          set the value below to true.  Set to false before deployment 
          to avoid disclosing exception information -->
					<serviceDebug includeExceptionDetailInFaults="False" />
				</behavior>
			</serviceBehaviors>
		</behaviors>
	</system.serviceModel>
```

# Interface:

```
using System.ServiceModel.Web;

/// <summary>
/// http://localhost:8734/WCFService1/Web/GetData?value=100
/// </summary>
/// <param name="value"></param>
/// <returns></returns>
[OperationContract]
[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
string GetData(int value);
```
