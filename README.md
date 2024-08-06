## Task

You need to develop a CLI utility that performs HTTP Health checks on a given URL.

The check is performed in a loop at a specified interval. On each iteration, an HTTP GET request is made to the given URL. There are three possible outcomes of the check:
1. `OK(200)` if the request returns an HTTP status code `200`.
2. `ERR({HTTP_CODE})` if the request returns an HTTP status code other than `200`.
3. `URL parsing error` if the second argument is not a valid HTTP URL, in which case the application terminates.

The utility accepts two arguments:
1. An integer value representing the interval in seconds.
2. The HTTP URL to be checked.

Example executions:
```shell
~$./my_binary 2 http://example.com/

Checking 'http://example.com/'. Result: OK(200)
Checking 'http://example.com/'. Result: OK(200)
Checking 'http://example.com/'. Result: OK(200)
^C
```
```shell
~$./my_binary 1 http://httpstat.us/500

Checking 'http://httpstat.us/500'. Result: ERR(500)
Checking 'http://httpstat.us/500'. Result: ERR(500)
^C
```
```shell
~$./my_binary 1 http://httpstat.us/503

Checking 'http://httpstat.us/503'. Result: ERR(503)
Checking 'http://httpstat.us/503'. Result: ERR(503)
^C
```
```shell
~$./my_binary 1 this_is_not_an_url

URL parsing error
```