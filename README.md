# ToDoAPI
This is a school project, where we're practicing the use of an API, using the new minimal API schema there's with .NET 6.0.

It is also to practice the use of an API overall, doing tests through PostMan, Unit tests or even the new HttpRepl. All depending on which software one person likes the most.


### Specifications
- [ ] To do API:
  - [ ] Able to GET all to-do items, which needs to be completed.
  - [ ] Able to GET **all** to-do items.
  - [ ] Able to GET a specific to-do item by using its ID.
  - [ ] Able to POST a new to-do item.
  - [ ] Able to PUT an existing to-do item by using its ID.
  - [ ] Able to DELETE an existing to-do item by using its ID.

### API Overview and Endpoints
| API                     | Description                    | Request body | Response body        |
|-------------------------|--------------------------------|--------------|----------------------|
| GET /                   | Browser test, "Hello, World!"  | None         | Hello World!         |
| GET /todoitems          | Get all to-do items            | None         | Array of to-do items |
| GET /todoitems/complete | Get completed to-do items      | None         | Array of to-do items |
| GET /todoitems/{ID}     | Get a to-do item by ID         | None         | To-do item           |
| POST /todoitems         | Add a new to-do item           | To-do item   | To-do item           |
| PUT /todoitems/{ID}     | Update an exisiting to-do item | To-do item   | None                 |
| DELETE /todoitems/{ID}  | Delete an existing to-do item  | None         | None                 |


### Use of third-party libraries
