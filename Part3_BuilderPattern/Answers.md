# Builder Pattern

## Task 3.1 --- Why Is a 20-Parameter Constructor a Problem?

1.  **Readability:** A constructor with many parameters is difficult to
    read and understand.
2.  **Error-prone calls:** The caller must remember the position of
    every parameter. Passing values in the wrong order is easy,
    especially when multiple parameters have the same type.
3.  **Difficult maintenance:** Adding a new parameter may require
    updating every constructor call, making the code harder to maintain
    and extend.

## Task 3.1 --- Question 2

The problem is deeper than having a long constructor. Putting many
loosely related properties into one class makes the class harder to
maintain and understand.

Although customer, billing, shipping, and order/payment information
belong to an invoice, they represent different logical groups. Keeping
all their details together without proper separation can make
validation, maintenance, and reuse more difficult. Grouping related
properties into smaller components can improve the design and reduce
duplicated logic.

## Task 3.3 --- Why Composed Builders Are Better

Splittig the `InvoiceBuilder` into smaller builders reduces complexity and makes the code easier to use
and understand.

-**Single Responsiblity Principle (SRP):** Each builder has a specific responsiblity. 
`AddressBuilder` handles address information, while `OrderBuilder` handles order and payment information.

-**Resuability:** `AddressBuilder` can be reused for both billing and shipping address informaion, without 
depending on the entire `Invoice`

-**Maintainability:** If address properties or their validation rules change, the changes can be made in one place 
instead of duplicating the same logic in multiple places.

-**Independent Validation:** Each builder can validate its own data independently, keeping address validation seperate from order and payment validation.

-**Readability:** Smaller builder make the construction process clearer and easier to understand.