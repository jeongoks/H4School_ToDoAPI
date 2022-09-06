# ToDoAPI
This is a school project, where we're practicing the use of an API, using the new minimal API schema there's with .NET 6.0.

It is also to practice the use of an API overall, doing tests through PostMan, Unit tests or even the new HttpRepl. All depending on which software one person likes the most.


### Specifications
- [x] To do API:
  - [x] Able to GET all to-do items, which needs to be completed.
  - [x] Able to GET **all** to-do items.
  - [x] Able to GET a specific to-do item by using its ID.
  - [x] Able to POST a new to-do item.
  - [x] Able to PUT an existing to-do item by using its ID.
  - [x] Able to DELETE an existing to-do item by using its ID.
- [ ] To do Web client:
  - [x] Index page which tells about the project, allow anonymous access.
  - [x] A TodoItems page, which shows all of the To-do items, which isn't completed.
    - [x] If you click on the To-do item's *description*, it will open a new Page where you can Edit properties. Remember validation of User input.
    - [x] Can also choose to delete the To-do item but, there needs to be a confirm Pop-up before it gets deleted. 
  - [x] On the front page, you will have the option to create a new To-do item.
    - [x] Maybe in the form of a Modal.
  - [ ] When you click on a To-do item's Checkbox to mark the task as *Completed*,the task will get removed from the shown list (Soft-delete)
  - [x] Make a TodoService, which injectes with Dependency Injection.
  - [x] The application's constants is placed in a AppConstants class.

### API Overview and Endpoints
| API                     | Description                    | Request body | Response body        |
|-------------------------|--------------------------------|--------------|----------------------|
| GET /                   | Browser test, "Hello, World!"  | None         | Hello World!         |
| GET /todoitems          | Get all to-do items            | None         | Array of to-do items |
| GET /todoitems/complete | Get completed to-do items      | None         | Array of to-do items |
| GET /todoitems/ID       | Get a to-do item by ID         | None         | To-do item           |
| POST /todoitems         | Add a new to-do item           | To-do item   | To-do item           |
| PUT /todoitems/ID       | Update an exisiting to-do item | To-do item   | None                 |
| DELETE /todoitems/ID    | Delete an existing to-do item  | None         | None                 |


### Use of third-party libraries
| Package name                                         | Version |
|------------------------------------------------------|---------|
| Microsoft.EntityFrameworkCore.InMemory               |  6.0.8  |
| Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore |  6.0.8  |
| Swashbuckle.AspNetCore                               |  6.2.3  |

### PostMan Tests
Because we're using an InMemory DB, we'll need to do a few **POST** calls before the **GET** calls will give the responses that we need when calling them.

| API Endpoint Call       | Test result |
|-------------------------|-------------|
| GET /                   | **Success** |
| GET /todoitems          | **Success** |
| GET /todoitems/complete | **Success** |
| GET /todoitems/ID       | **Success** |
| POST /todoitems         | **Success** |
| PUT /todoitems/ID       | **Success** |
| DELETE /todoitems/ID    | **Success** |

### HTTPRepl Scripting
<details><summary>Click to see Scripting options</summary>
  
  \
  I've already prepared my HTTPRepl to use VS code as the default editor for the **POST** and **PUT** calls.
  \
  \
  First you need to connect to your API, this means that that will be your working directory.
  
  ```
  httprepl https://localhost:7221
  ```
  \
  After that we need to start by running the **POST** in order to get items in your InMemory DB.
  \
  Connect to the directory of /todoitems.
  ```
  cd todoitems
  ```
  \
  When you've access that, then you will write following code, which opens the default editor of choice.
  \
  You will write your json object, save and then close the editor.
  \
  ```
  post -h {Content-Type}:{application/json}
  ```
  \
  After that you can start running all the **GET** calls.
  \
  To get all those To-do items which haven't been completed yet.
  ```
  cd notCompleted
  ```
  Once inside the https://localhost:7221/todoitems/notCompleted then retrieve all *not*-completed To-do items.
  ```
  get
  ```
  \
  To **GET** *all* To-do items.  ```cd ..```  to get back to our https://localhost:7221/todoitems
  ```
  cd ..
  ```
  Now you're back in the working directory, and you call a **GET** to retrieve all existing To-do items.
  ```
  get
  ```
  \
  Getting a specific existing To-do item, then you simply write the ID that you want to access.
  \
  Which I've chosen to be the first ID.
  ```
  cd 1
  ```
  \
  This shows a list of put **GET** **PUT** and **DELETE**
  \
  
  To **PUT** the To-do item, you will get a editor to open where you do the changes, save and close.
  ```
  put -h {Content-Type}:{application/json}
  ```
  \
  The same goes for the **DELETE**.
  ```
  delete -h {Content-Type}:{application/json}
  ```
  \
  And the **GET** is just like all of the previous **GET** calls.
  ```
  get
  ```
</details>
