# Bank System with Three-Tier Architecture

This repository contains a comprehensive bank system project developed using a three-tier architecture, comprising distinct layers for business logic, data access, and user interface components.

## Overview

The bank system is designed to simulate the operations of a real-world banking application, offering a range of functionalities including users management, clients management, transactions handling, login registration, and transfer logs management. The three-tier architecture ensures modularity, scalability, and maintainability by separating concerns between the business logic, data access, and user interface layers.

## Three-Tier Architecture Layers

### 1. Business Layer (BankSystem.BLL)

The Business Layer serves as the heart of the system, encapsulating the core business logic and rules governing banking operations. It includes functionalities for users management, clients management, transactions processing, login registration, and transfer logs management.

### 2. Data Access Layer (DataAccessLayer)

The Data Access Layer facilitates seamless interaction with the database, handling data retrieval, storage, and manipulation tasks related to users, clients, transactions, login details, and transfer logs. It abstracts the underlying database interactions, promoting secure and efficient communication with the bank's data storage.

### 3. User Interface (BankSystem.UI)

The User Interface layer provides the visual components and interactive elements that enable users to interact with the bank system. It offers intuitive WinForms interfaces for users to manage their accounts, view transaction history, transfer funds, and access various banking services.

## Functionalities

### Users Management
- Create, update, and delete user accounts
- Manage user roles and permissions
- Authenticate users securely

### Clients Management
- Add and manage client accounts
- View client details and account information
- Perform client-related transactions

### Transactions
- Process various types of transactions (withdrawals, deposits, transfers)
- Track transaction history and details
- Ensure transaction security and integrity

### Login Registration
- Register new users securely
- Manage user authentication and access control
- Implement secure login mechanisms

### Transfer Logs Management
- Record and manage transfer logs
- Track fund transfers between accounts
- Ensure transparency and accuracy in transfer records
