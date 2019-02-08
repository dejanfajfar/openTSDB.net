# openTSDB.net

* * *

**Notice:** This is not the openTSD.net web page repository. If you are looking for this then try [HERE](https://github.com/OpenTSDB/opentsdb.net)

* * *


[![Build status](https://ci.appveyor.com/api/projects/status/pkru2h61f9cxegy6/branch/master?svg=true)](https://ci.appveyor.com/project/dejanfajfar/opentsdb-net-985f2/branch/master)
[![](https://img.shields.io/nuget/v/opentsdb.net.svg)](https://www.nuget.org/packages/Epoch.net/)
![](https://img.shields.io/nuget/dt/opentsdb.net.svg)

## Introduction

openTSDB.net is a low weight, low impact implementation of a application to OpenTSDB bridge.

### Scope

Although the openTSDB API is powerfull this library concentrates on one thing. 

> Getting data into the openTSDB 

This is the only concern of this library. If you want a more _complete_ interaction model then please contact me.

## Installation

### NuGet

```bash
PM> Install-Package openTSDB.net
```

## Glossary

| Term | Definition |
|----|----|
| Named instance | A instance of the __manager__ that can be accessed using a globally unique name and the same instance shared by many |
| Anonymous instance | A instance of the __manager__ that can not be accessed using a name and therefore can not be retrieved multiple time from the __factory__ |
| Manager | The openTsdb factory is the entry point of the library, but the __manager__ is the core implementation and object that the __client__ is interacting with |

## Getting started

Hit the ground running

### Working the factory

_OpenTsdb.net_ uses a factory pattern to provide "unknown" and named instances of the __manager__.

#### Named instances

```c#
var tsdbManager = OpenTsdbFactory.Instance(TsdbOptions.New("http://localhost:4242"), "myInstance");
```

Where __myInstance__ is the instance identifier. 

If the instance was already initialized by someone else then the same instance will be returned.

#### Anonymous instance

```c#
var tsdbManager = OpenTsdbFactory.Instance(TsdbOptions.New("http://localhost:4242"));
``` 

### Publishing data

The point of this all is to get data into the openTSDB database. 

This can be done...

#### Quick and easy

If we want to publish only one data point then this can easily be achieved by 

```c#
tsdbManager.PushAsync<int>("login", 1);
``` 

#### More control more code

There is also a longer way that provides more control over the data transmitted.

```c#
var dataPoint = new DataPoint<int>
{
    Value = 23,
    Metric = "user_age",
    Timestamp = DateTime.Now.ToEpoch(),
    Tags = new TagsCollection()
};

var result = tsdbManager.PushAsync<int>(dataPoint);
```
