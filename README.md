>  This project was created with intention to familiarize myself with AutoFixture framework

*Translated by DeepL.com*
# Run and familiarize yourself with the project Test its functionality.

## The attached project is a console application that allows you to manage groups of students. The system allows you to create groups and students, place students in groups and remove students from the system.

Create a series of unit tests testing the attached project:

### 1. for the AddNewGroup method

a. Test for a correctly executed method (expected result: True)

b. Test for the situation when the inserted group already exists (expected result: False)

### 2. for the AddNewUserToClass method

a. Test for a correctly executed method (expected result: True)

b. Test for the situation when the group to which we are adding a student does not exist (expected result: exception reported)

### 3. for the GetUserById method

a. Test for a correctly executed method (expected result: the object exists and contains the expected data)

b. Test for the situation when the searched object does not exist (expected result: the object is null)

### 4. for the CreateUser method

a. Test for a correctly executed method (expected result: the object created and contains the expected data)

b. One test for the situation when the first name or last name is empty or null (expected result: exception reported)

c. One test for the situation when the entered User already exists (expected result: reported exception)

### 5. for RemoveUser method

a. Test for the correct operation of the method

Use AutoFixture to generate test data.

Additionally: Add a method in the project to edit the student searched by the given Id and write two unit tests to check the correct operation of the method and the operation of the method when the student with the given id does not exist.

Note: In the project, the group and the class to which students can belong are the same! (i.e., for example, AddNewGroup - is a method that adds a student to a class).

Translated with DeepL.com (free version)
