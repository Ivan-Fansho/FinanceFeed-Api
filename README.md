# FinanceFeed-Api

A platform to store stocks and comment on stocks also add stocks to portfolio.
This project is still work in progress
# API Documentation

## Table of Contents
- [Account Controller](#account-controller)
  - [POST /api/account/login](#post-apiaccountlogin)
  - [POST /api/account/register](#post-apiaccountregister)
- [Portfolio Controller](#portfolio-controller)
  - [GET /api/portfolio](#get-apiportfolio)
  - [POST /api/portfolio](#post-apiportfolio)
  - [DELETE /api/portfolio](#delete-apiportfolio)
- [Stock Controller](#stock-controller)
  - [GET /api/stock](#get-apistock)
  - [GET /api/stock/{id:int}](#get-apistockidint)
  - [POST /api/stock](#post-apistock)
  - [PUT /api/stock/{id:int}](#put-apistockidint)
  - [DELETE /api/stock/{id:int}](#delete-apistockidint)
- [Comment Controller](#comment-controller)
  - [GET /api/comment](#get-apicomment)
  - [GET /api/comment/{id:int}](#get-apicommentidint)
  - [POST /api/comment/{stockId:int}](#post-apicommentstockidint)
  - [PUT /api/comment/{id:int}](#put-apicommentidint)
  - [DELETE /api/comment/{id:int}](#delete-apicommentidint)

---

## Account Controller

### POST /api/account/login

- **Description**: Authenticates a user by checking their username and password.
- **Request Body**:
    ```json
    {
      "userName": "string",
      "password": "string"
    }
    ```
- **Responses**:
    - **200 OK**: Returns user data and a token if login is successful.
      ```json
      {
        "userName": "string",
        "email": "string",
        "token": "string"
      }
      ```
    - **400 Bad Request**: Invalid request data.
    - **401 Unauthorized**: Invalid username or password.

---

### POST /api/account/register

- **Description**: Registers a new user and returns a token.
- **Request Body**:
    ```json
    {
      "username": "string",
      "email": "string",
      "password": "string"
    }
    ```
- **Responses**:
    - **200 OK**: Returns user data and a token after successful registration.
      ```json
      {
        "userName": "string",
        "email": "string",
        "token": "string"
      }
      ```
    - **400 Bad Request**: Invalid request data.
    - **500 Internal Server Error**: An error occurred during user creation or role assignment.

---

## Portfolio Controller

### GET /api/portfolio

- **Description**: Retrieves the authenticated user's portfolio.
- **Responses**:
    - **200 OK**: Returns the user's portfolio.
      ```json
      [
        {
          "symbol": "string",
          "stockId": "int",
          "appUserId": "int"
        }
      ]
      ```
    - **401 Unauthorized**: User is not authenticated.

---

### POST /api/portfolio

- **Description**: Adds a stock to the authenticated user's portfolio.
- **Request Body**:
    ```json
    {
      "symbol": "string"
    }
    ```
- **Responses**:
    - **200 OK**: Successfully added the stock to the portfolio.
    - **400 Bad Request**: Stock does not exist or already in the portfolio.
    - **401 Unauthorized**: User is not authenticated.
    - **500 Internal Server Error**: Error occurred during stock addition.

---

### DELETE /api/portfolio

- **Description**: Deletes a stock from the authenticated user's portfolio.
- **Request Body**:
    ```json
    {
      "symbol": "string"
    }
    ```
- **Responses**:
    - **204 No Content**: Successfully deleted the stock from the portfolio.
    - **400 Bad Request**: Stock not found in the portfolio.
    - **401 Unauthorized**: User is not authenticated.

---

## Stock Controller

### GET /api/stock

- **Description**: Retrieves a list of stocks based on query parameters.
- **Request Query Parameters**:
    - `pageNumber`: Optional, current page number.
    - `pageSize`: Optional, number of items per page.
- **Responses**:
    - **200 OK**: Returns a list of stocks.
      ```json
      [
        {
          "id": "int",
          "symbol": "string",
          "price": "decimal",
          "otherFields": "..."
        }
      ]
      ```
    - **400 Bad Request**: Invalid request query.

---

### GET /api/stock/{id:int}

- **Description**: Retrieves a specific stock by its ID.
- **Path Parameter**:
    - `id`: Stock ID (integer).
- **Responses**:
    - **200 OK**: Returns the stock details.
      ```json
      {
        "id": "int",
        "symbol": "string",
        "price": "decimal",
        "otherFields": "..."
      }
      ```
    - **400 Bad Request**: Invalid stock ID or bad request.
    - **404 Not Found**: Stock with the given ID does not exist.

---

### POST /api/stock

- **Description**: Creates a new stock.
- **Request Body**:
    ```json
    {
      "symbol": "string",
      "price": "decimal",
      "otherFields": "..."
    }
    ```
- **Responses**:
    - **201 Created**: Returns the created stock.
      ```json
      {
        "id": "int",
        "symbol": "string",
        "price": "decimal",
        "otherFields": "..."
      }
      ```
    - **400 Bad Request**: Invalid request body.

---

### PUT /api/stock/{id:int}

- **Description**: Updates a stock by its ID.
- **Path Parameter**:
    - `id`: Stock ID (integer).
- **Request Body**:
    ```json
    {
      "symbol": "string",
      "price": "decimal",
      "otherFields": "..."
    }
    ```
- **Responses**:
    - **200 OK**: Returns the updated stock.
      ```json
      {
        "id": "int",
        "symbol": "string",
        "price": "decimal",
        "otherFields": "..."
      }
      ```
    - **400 Bad Request**: Invalid request body or stock does not exist.

---

### DELETE /api/stock/{id:int}

- **Description**: Deletes a stock by its ID.
- **Path Parameter**:
    - `id`: Stock ID (integer).
- **Responses**:
    - **204 No Content**: Successfully deleted the stock.
    - **400 Bad Request**: Invalid request.
    - **404 Not Found**: Stock with the given ID does not exist.

---

## Comment Controller

### GET /api/comment

- **Description**: Retrieves all comments.
- **Responses**:
    - **200 OK**: Returns a list of comments.
      ```json
      [
        {
          "id": "int",
          "content": "string",
          "createdAt": "string",
          "stockId": "int",
          "appUserId": "int"
        }
      ]
      ```
    - **401 Unauthorized**: User is not authenticated.

---

### GET /api/comment/{id:int}

- **Description**: Retrieves a specific comment by its ID.
- **Path Parameter**:
    - `id`: Comment ID (integer).
- **Responses**:
    - **200 OK**: Returns the comment details.
      ```json
      {
        "id": "int",
        "content": "string",
        "createdAt": "string",
        "stockId": "int",
        "appUserId": "int"
      }
      ```
    - **400 Bad Request**: Invalid comment ID or bad request.
    - **404 Not Found**: Comment with the given ID does not exist.

---

### POST /api/comment/{stockId:int}

- **Description**: Creates a new comment for a specific stock.
- **Path Parameter**:
    - `stockId`: Stock ID (integer).
- **Request Body**:
    ```json
    {
      "content": "string"
    }
    ```
- **Responses**:
    - **201 Created**: Returns the created comment.
      ```json
      {
        "id": "int",
        "content": "string",
        "createdAt": "string",
        "stockId": "int",
        "appUserId": "int"
      }
      ```
    - **400 Bad Request**: Invalid request body or stock does not exist.

---

### PUT /api/comment/{id:int}

- **Description**: Updates a comment by its ID.
- **Path Parameter**:
    - `id`: Comment ID (integer).
- **Request Body**:
    ```json
    {
      "content": "string"
    }
    ```
- **Responses**:
    - **200 OK**: Returns the updated comment.
      ```json
      {
        "id": "int",
        "content": "string",
        "createdAt": "string",
        "stockId": "int",
        "appUserId": "int"
      }
      ```
    - **400 Bad Request**: Invalid request body or comment does not exist.

---

### DELETE /api/comment/{id:int}

- **Description**: Deletes a comment by its ID.
- **Path Parameter**:
    - `id`: Comment ID (integer).
- **Responses**:
    - **204 No Content**: Successfully deleted the comment.
    - **400 Bad Request**: Invalid request.
    - **404 Not Found**: Comment with the given ID does not exist.
