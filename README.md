# HolidaySearch

The above solution contains an interesting piece of code. I made an assumption that the search that the potential customer made could have missing or incorrect information that was not an exact match in the json files. To counter this i have given each attribute a weighting system. An exact match is taken as highest priority, with the cheapest price flight/hotel returned in the event of 2 or more exact matches. Failing exact matches there is a weighting given to each part of the request and ultimately the result with the highest 'score' is returned given certain criteria such as Destination being most important.
