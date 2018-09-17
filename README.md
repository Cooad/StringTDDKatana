# StringTDDKatana
The idea for this project is to practice TDD.

The purpose is to create a simple class/method that adds delimited values from a string.
The list of test is as follows:
1. An empty string returns zero
2. A single number returns the value
3. Two numbers, comma delimited, returns the sum
4. Two numbers, newline delimited, returns the sum
5. Three numbers, delimited either way, returns the sum
6. Negative numbers throw an exception
7. Numbers greater than 1000 are ignored
8. A single char delimiter can be defined on the first line (e.g. //# for a ‘#’ as the delimiter)
9. A multi char delimiter can be defined on the first line (e.g. //[###] for ‘###’ as the delimiter)
10. Many single or multi-char delimiters can be defined (each wrapped in square brackets)

The attempts are segregated into separate branches

The idea came from the follwing article:
http://www.peterprovost.org/blog/2012/05/02/kata-the-only-way-to-learn-tdd/
