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