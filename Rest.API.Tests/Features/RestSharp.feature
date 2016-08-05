Feature: RestSharp
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@RestSharp
Scenario: RestSharp Example
	Given I have an example endpoint http://www.thomas-bayer.com/sqlrest/
	When I search for all customers
	Then the result contains customer Laura


Scenario Outline: RestSharp Get Customer Record
 	Given I have an example endpoint http://www.thomas-bayer.com/sqlrest/
 	When I search for customer record 0
 	Then the result contains customer <ID>
 	Then the result contains customer <First Name>
 	Then the result contains customer <Last Name>
 	Then the result contains customer <Street>
 	Then the result contains customer <City>
 
 	Examples: 
 	| ID | First Name | Last Name | Street          | City   |
 	| 0  | Laura      | Steel     | 429 Seventh Av. | Dallas |

Scenario: Post Product Price
 	Given I have an example endpoint http://www.thomas-bayer.com/sqlrest/
 	And I update the price of Product 1 to 10.00
 	When I search for Product 1
 	Then the price is 10.00
	And I reset the price of product 1 to 24.8