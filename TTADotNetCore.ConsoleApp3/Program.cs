﻿// See https://aka.ms/new-console-template for more information
using TTADotNetCore.ConsoleApp3;

Console.WriteLine("Hello, World!");

//Api Methods
//get
//post
//put
//patch
//delete

//resource
//endpoint

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Read();
//await httpClientExample.Edit(1);
//await httpClientExample.Edit(101);
//await httpClientExample.Create("test title", "test body", 1);
//await httpClientExample.Update(1,"test title", "test body", 10);

Console.WriteLine("Waiting for Api....");
Console.ReadLine();

RefitExample refitExample = new RefitExample();
await refitExample.Run();


