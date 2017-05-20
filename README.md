# openTSDB.net

* * *

**Notice:** This is not the openTSD.net web page repository. If you are looking for this then try [HERE](https://github.com/OpenTSDB/opentsdb.net)

* * *

[![codecov](https://codecov.io/gh/dejanfajfar/openTSDB.net/branch/master/graph/badge.svg)](https://codecov.io/gh/dejanfajfar/openTSDB.net)


[![Build status](https://ci.appveyor.com/api/projects/status/pjcln0nojvv3lapp?svg=true)](https://ci.appveyor.com/project/dejanfajfar/opentsdb-net)

# Introduction

openTSDB.net is a low weight, low impact implementation of a application to OpenTSDB bridge.

## Scope

Although the openTSDB API is powerfull this library concentrates on one thing. 

> Getting data into the openTSDB 

This is the only concern of this library. If you want a more _complete_ interaction model then please contact me.

# Installation

## NuGet

```bash
PM> Install-Package openTSDB.net
```

## From code

You can clone the project in into your local solution and use it as this. 

This day in age this is highly discouraged. 

# Usage

## Common setup

Before we can publish data to the openTSDB we have to provide some information, and initialaze a factory.

```csharp
var tsdbManager = OpenTsdbFactory.TsdbManager(new TsdbOptions
{
    OpenTsdbServerUri = new Uri({openTsdbURI}),
    DefaultTags = new TagsCollection({hostName})
})
```

Two things have to be provided:
* __openTsdbURI__ : location of the openTSDB without the api relative part
* __hostName__ : the name of the host from which the data is published has to be provided.

## Publlish single data point 

There a two ways to publish a data point:
* by creating the data point instance and sending it
* using the shorthand method

### Create data point instance

```cshap
var dataPoint = new DataPoint<int>
{
    Value = {metricValue},
    Metric = "{metricName}",
    Timestamp = DateTime.Now.ToEpoch(),
    Tags = new TagsCollection()
};

var result = tsdbManager.Push(dataPoint);
```

### Shorthand method

```csharp
var result = tsdbManager.Push({metricName}, {metricValue});
```
