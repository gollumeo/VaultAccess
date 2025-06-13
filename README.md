# VaultAccess

## 🧠 What is this?

This repository is a TDD-first, DDD-aligned sandbox for modeling access request logic — without shortcuts, frameworks, or surface-level architecture.

The goal is to **relearn how to model code through behavior**, not structure.

---

## 🎯 What does it cover?

- Modeling an `AccessRequest` as a domain entity
- Encapsulating all transitions and invariants (no setters, no external mutation)
- Externalizing business rules via static `AccessRequestRules`
- Full TDD workflow: no method, class or branch exists without a test
- Usage of **domain exceptions**, not generic logic

---

## ✅ Modeled Use Cases

- Submit an access request
- Approve a pending access request
- Reject a pending access request

Each use case is test-covered, minimal, and strictly intention-driven.

---

## 🧱 Core Design Principles

- Tell Don’t Ask enforced
- Domain model is defensive (will throw if misused)
- No persistence, no infrastructure, no controller (yet)
- No injection, no overengineering — just clarity of domain

---

## 🤖 What's next?

If extended, the project might include:

- EF Core repository for persisting `AccessRequest`
- Read models or projections
- State transition map (`AccessRequestLifecycle`)
- DomainEvents for integration purposes

But none of this exists yet.

---

## 🚫 What this is NOT

- A real API
- A production-ready service
- A template for boilerplate

This is **a living kata** for modeling intent-first backend logic in C#.
