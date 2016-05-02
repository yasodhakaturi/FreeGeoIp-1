# FreeGeoIp
Simple client for calling free IP geolocation api at freegeoip.net

## Usage

    var response = new FreeGeoIp.Client().Get(ipAddress)
		
## Response

`GeoIpResponse` object with the following properties:

 - _string_ Ip
 - _string_ CountryCode
 - _string_ CountryName
 - _string_ RegionCode
 - _string_ RegionName
 - _string_ City
 - _string_ ZipCode
 - _string_ TimeZone
 - _long_ Latitude
 - _long_ Longitude
 - _int_ MetroCode
 
## Errors

The freegeoip.net API is limited to 10,000 queries per hour, after this all requests will result in HTTP 403 (Forbidden) until the quota is cleared.

The client supports simple error logging via the `IErrorLog` interface, which has a single method with the signature `void Log(string error)` which is called when an error is encountered (typically only the 403).

This is used as follows:

    IErrorLog errorLog = GetMyErrorLogImplementation();
		var client = new FreeGeoIp.Client() { ErrorLog = errorLog };