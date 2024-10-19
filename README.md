# .NET Hosting API and Native AOT

This project shows how to consume the .NET hosting API from a .NET NativeAOT application.

When compiled as debug, the `nethost` library is loaded dynamically, so that the application can be
run as a normal .NET app on CoreCLR. In release configuration, the `nethost` library is statically
linked. Therefore when compiled as release the app only works as a NativeAOT app.

## References

* [Write a custom .NET host to control the .NET runtime from your native code](https://learn.microsoft.com/en-us/dotnet/core/tutorials/netcore-hosting)
* [Native code interop with Native AOT](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/interop)
