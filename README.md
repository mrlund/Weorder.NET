# Weorder.NET

Community contributed NETStandard 2.0 client for the Weorder API

This plugin is *not* developed or maintained by Weorder but kindly made
available by the community.

Released under the MIT license: https://opensource.org/licenses/MIT

**Installation**
`nuget install Weorder.NET`
-or-
`dotnet add package Weorder.NET`

**WeorderPOSClient**
```c#
var posClient = new WeorderPOSClient(HttpClient httpClient, string accessToken = null, ILoggerFactory logger = null)
```

**WeorderOrderingClient**
```c#
var orderingClient = new WeorderOrderingClient(HttpClient httpClient, string accessToken = null, ILoggerFactory logger = null)
```

Methods:
* void SetAccessToken(string accessToken)  

Generally the client follows the Weorder API docs in use to make it as intuitive as possible. Consider the  
[Weorder POS HUB](https://poshub.weorder.com/docs/?url=/docs/file/api.yaml) API docs, and compare with the examples below:

Examples:
```c#
var integrations = await orderingClient.Integrations.Get("integration-id"); 
```
```c#
var order = await orderingClient.Orders.Create(Order order); 
```
```c#
var inventory = await orderingClient.Inventory.Get("integration-id", "inventory-id"); 
```
```c#
var tableSession = await orderingClient.TableSessions.Checkout("integration-id", "table-session-id"); 
```


# Available services

**Integrations**

* Task<WeorderApiResponse<List<Integration\>>> Get();
* Task<WeorderApiResponse<Integration\>> Get(string integrationId);
* Task<WeorderApiResponse<Integration\>> Create(Integration integration);
* Task<WeorderApiResponse<Integration\>> Update(Integration integration);
* Task<WeorderApiResponse<Integration\>> Refresh(string integrationId);
* Task<WeorderApiResponse<Integration\>> Update(Integration integration);
* Task<WeorderApiResponse<Integration\>> Enable(string integrationId);
* Task<WeorderApiResponse<Integration\>> Disable(string integrationId);


**Order**

* Task<WeorderApiResponse<Order\>> Cancel(string integrationId, string orderId);
* Task<WeorderApiResponse<Order\>> Create(string integrationId, Order order);


**Inventory**

* Task<WeorderApiResponse<Inventory\>> Get(string integrationId, string inventoryId);


**TableSession**

* Task<WeorderApiResponse<TableSession\>> Get(string integrationId, string tableSessionId);
* Task<WeorderApiResponse<TableSession\>> Checkout(string integrationId, string tableSessionId);
* Task<WeorderApiResponse<TableSession\>> Uncheckout(string integrationId, string tableSessionId);
* Task<WeorderApiResponse<TableSession\>> ConfirmPayment(string integrationId, string tableSessionId);
