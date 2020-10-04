## TrampolineGuard

Tired of finding your trampoline in your neighbours garden because the wind has blown it over? Or how about not finding it at all?? Fear no more, TrampolineGuard is there!

This is the source code for a service where you will get warnings when the wind speed reaches your configured value! No more sad kids because the neighbour now has two trampolines and you none!

### Configuration

Add the following secrets/configuration:

```
{
  "onlineServiceAuthId": "authid",
  "onlineServiceAuthToken": "authToken",
  "onlineServiceSource": "serviceName",

  "userAgent": "user agent as defined by yr.no",
  "lat": "latitude",
  "lng": "longitude",
  "windLimit": "wind speed limit",

  "recipient": "phone number",
  "serviceOkMessage": "OK MESSAGE",
  "warningMessage": "WARNING MESSAGE"
}
```

### Todo

- Tests
- Email integration
- other...

##### Credits

This project was possible with data from [Yr.no](http://yr.no), [https://hjelp.yr.no/hc/en-us](https://hjelp.yr.no/hc/en-us)

##### Contribute?

Feel free to drop me a message. Mail on [contact page](https://github.com/larsfagerbakke). Create pull request :-).