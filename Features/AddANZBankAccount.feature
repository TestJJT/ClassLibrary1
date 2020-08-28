Feature: Adding ANZ(NZ) account types
	As a Xero User
	In order to manage my business successfully
	I wannt to be able to add an "ANZ(NZ)" bank account inside any Xero Organisation

Scenario: Add an ANZ(NZ) account of type "Everyday (day-to-day)"
   Given the user is logged in
   When the user adds ANZ(NZ) "Everyday (day-to-day)" account with account number "06099812345731" named "TestEveryAcct1"
   Then the account should be saved and Connect with Bank suggested to user
   

Scenario: Add an ANZ(NZ) account of type "Other"
	Given the user is logged in
    When the user adds ANZ(NZ) "Other" account with account number "060998123456700" named "TestOtherAcct"
	Then the account should be saved and displayed under Bank Accounts
	

Scenario: Add an ANZ(NZ) account of type "Loan"
	Given the user is logged in
    When the user adds ANZ(NZ) "Loan" account with account number "060998123456" named "TestloanAcct"
	Then the account should be saved and Connect with Bank suggested to user


Scenario: Add an ANZ(NZ) account of type "Term Deposit"
	Given the user is logged in
    When the user adds ANZ(NZ) "Term Deposit" account with account number "060998123457" named "TestTDAcct"
	Then the account should be saved and Connect with Bank suggested to user


Scenario: Add an ANZ(NZ) account of type "Credit Card"
   Given the user is logged in
   When the user adds ANZ(NZ) "Credit Card" account with account number "4321" named "TestCreditAcct1"
   Then the account should be saved and Connect with Bank suggested to user

