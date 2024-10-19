# .NET Hosting API and Native AOT

This project shows how to consume the .NET hosting API from a .NET NativeAOT application.

## TODO

There is one major problem with the application as written: it only works when published as a
NativeAOT application. This is because it uses static linking with the `nethost` API. Ideally it
would support using dynamic linking with the `nethost` API so that the application could be tested
as a regular .NET app running on CoreCLR.

## References

* [Write a custom .NET host to control the .NET runtime from your native code](https://learn.microsoft.com/en-us/dotnet/core/tutorials/netcore-hosting)
* [Native code interop with Native AOT](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/interop)
