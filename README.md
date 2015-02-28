# Contentful.NET

[![Build status](https://ci.appveyor.com/api/projects/status/vvgdd96miyl217nv?svg=true)](https://ci.appveyor.com/project/ryan-codingintrigue/contentful-net)

A .NET library wrapper for the Contentful [Content Delivery API](https://www.contentful.com/developers/documentation/content-delivery-api/).

## Project Goals & Contributions

This library aims to provide a wrapper around all of the functionality provided by the Contentful Content Delivery API in a manner which is familiar to .NET developers.

Contributions are of course welcomed via pull request. I'd also appreciate any feedback on code quality and issues so that I can improve the project.

## Installation

Via Nuget:
> Install-Package Contentful.NET

## Usage

The `ContentfulClient` is the main implementation of the API. It can be injected as a dependency by using the `IContentfulClient` interface. It requires a valid Access Token and a SpaceId passed in as a constructor:
```cs
IContentfulClient client = new ContentfulClient("productionAccessToken", "spaceId");
```

It contains two methods:
```cs
GetAsync<T>(id)
```

Returns a single item from the API
```cs    
SearchAsync<SearchResult<T>>(searchFilters, orderByProperty, orderByDirection, skip, limit, includeLevels)
```
    
Returns a set of results based on the provided search criteria.

Above, `T` is an implementation of an `IContentfulItem` which can currently be one of four different types of items as defined by the Contentful API: 

- Spaces
- Content Types
- Entries
- Assets

### Search Filters

A "Search Filter" is a .NET representation of the [Search Parameters](https://www.contentful.com/developers/documentation/content-delivery-api/#search) available on the Content Delivery API. They should be passed
into the SearchAsync method as an `IEnumerable<ISearchFilter>`. The API provides the following pre-defined filters:

- `EqualitySearchFilter`: Compares string values for direct (in)equality
- `NumericSearchFilter`: Compares numeric using the `<`, `<=`, `>` and `>=` operators
- `DateTimeSearchFilter`: Compares Date/Time using the `<`, `<=`, `>` and `>=` operators
- `FullTextSearchFilter`: Searches a field (or all fields) using a Full Text query
- `InclusionSearchFilter`: Searches within an array for a given value

Custom comparators may be created by implementing the `ISearchFilter` interface.

### Include Levels

Inclusion of linked Assets/Entries is supported by the API and are stored inside the `SearchResult<T>` result returned from a `SearchAsync` call, but only if the `includeLevels` parameter is passed. This should be an
integer value between 1 and 10, indicating the number of levels deep the API should go to look for linked Assets/Entries

### Built-In Properties

When creating `SearchFilters`, it is sometimes useful to query standard Contentful properties. These standard properties and stored in a static context in the `BuiltInProperties` class, for example:
```cs
var contentTypeFilter = new EqualitySearchFilter(BuiltInProperties.ContentType, "contentTypeId");
var createdAfterFilter = new DateTimeSearchFilter(BuiltInProperties.SysCreatedAt, DateTime.UtcNow.AddDays(-7), NumericEquality.GreaterThanEqual);
```
	
### Image Helper

The Contentful service offers a way of resizing image assets stored within the Contentful CDN. These URLs can be generated using the `ImageHelper` static class, for example:
```cs
var asset = await GetAsync<Asset>("assetId");
var thumbnailImage = ImageHelper.GetResizedImageUrl(
    asset.Details.File.Url, // Original URL
    150, // Maximum width constraint
    100, // Maximum height constraint
    ImageType.Jpg, // Image format
    75 // (Optional) JPEG Compression Quality
);
```

### Examples

**Get a single Entry by specifying its ID:**
```cs
var entry = await GetAsync<Entry>("entryId");
```
**Search all Entries with Content Type "cat":**
```cs
var results = client.SearchAsync<Space>(cancellationToken, new[]
{
    new EqualitySearchFilter(BuiltInProperties.ContentType, "cat")
});
```
**Do a full-text search on all Entries with Content Type "cat":**
```cs
var results = client.SearchAsync<Space>(cancellationToken, new ISearchFilter[]
{
    new EqualitySearchFilter(BuiltInProperties.ContentType, "cat"),
    new FullTextSearchFilter("manx")
});
```
**Search for all "cat" Entries updated since January 1st:**
```cs
var results = client.SearchAsync<Space>(cancellationToken, new ISearchFilter[]
{
    new EqualitySearchFilter(BuiltInProperties.ContentType, "cat"),
    new DateTimeSearchFilter(BuiltInProperties.SysUpdatedAt, new DateTime(DateTime.Now.Year, 1, 1), NumericEquality.GreaterThanEqualTo),
});
```
### Kitchen Sink Demo

The repository contains the `KitchenSink` project which is an ASP.NET MVC 5 web project which attempts to give a practical example of the API. It's
somewhat complete, but it could use a little bit more work.
