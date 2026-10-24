# Procedural C++ to Object-Oriented C#

## 1. Fixed-Size Data Storage

**Problem:** The System uses fixed-size arrays to store data.

**Why it is a problem:** The number of customers, products, and orders that the system can store 
is limited by the array capacities.

**What could go wrong:** when the system reaches its capacity, it may be unable to add new records without 
changing the array sizes and modifying related code.

## 2. Lack of Clear Data Ownership

**Problem:** Data is stored in global variables and manipulated by seperate functions, 
rather than being owned by objects.

**Why it is a problem:** There is no clear relationship between the data and the operations responsible for 
managing it. This makes the code harder to maintain and extend.

**What could go wrong:** Adding new features may require chages in several functions, 
increasing the risk of introducing bugs.

## 3. Global Mutable State

**problem:** Global data can be accessed and modified by multiple functions. 

**Why it is a problem:** It is difficult to control which parts of the program can change the data and 
to ensure that all modifications follow the same rules.

**What could go wrong:** An incorrect modification may leave the program's data in an inconsistent state, 
especially as the application grows.

## 4. Parallel Arrays

**problem:** Related information is stored in seperate arrays, with corresponding records connected through 
their indexes.

**Why it is a problem:** The program must maintain the correct alignment between arrays whenever records are added, modified, or accessed.

**What could go wrong:** An incorrect index or an inconsistent update could associate the wrong information with 
the customer, product, or order.