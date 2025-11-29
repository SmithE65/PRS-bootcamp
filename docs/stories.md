# v1 Workflows

## Roles quick ref

* **Requester**: browse products, create/edit/submit PRs; delete PR **only if status ≠ `submitted`**.
* **Reviewer**: approve/reject submitted PRs.
* **Admin**: add/edit/delete vendors/products (with your delete guards).

# Foundational tasks
- [ ] Create Angular app
  - [ ] 


# v1 User Stories

## Requester

1. **View my PRs**

   * *I want* a list of my PRs filtered by status.
   * **AC:** Can filter by `draft/submitted/approved/rejected`; clicking shows details.

1. **Create draft PR**

   * *As a* requester, *I want* to start a purchase request by picking products and quantities, *so that* I can justify an order.
   * **AC:** Can add ≥1 product; can enter description, justification, date_needed, delivery_mode; draft is saved with a generated id.

1. **Edit draft PR**

   * *I want* to change quantities, add/remove products, and update fields.
   * **AC:** Changing items updates the displayed total; unsaved changes warning on navigation.

1. **Submit PR**

   * *I want* to submit a draft for approval.
   * **AC:** On submit, server recalculates total; if total ≤ threshold → PR shows `approved`; else `submitted`; submitted PR becomes read-only.

1. **Delete PR (when allowed)**

   * *I want* to delete a PR that isn’t `submitted`.
   * **AC:** Delete button appears only for `draft/approved/rejected`; requires confirm; after delete it no longer appears in my list.

1. **Resubmit after rejection**

   * *I want* to correct a rejected PR and resubmit.
   * **AC:** Rejected PR becomes editable; on submit, status goes to `submitted` or `approved` (threshold).

## Reviewer

1. **See review queue**

   * *As a* reviewer, *I want* a queue of `submitted` PRs.
   * **AC:** Shows requester, total, date_needed; sorted by date_needed desc/asc toggle.

1. **Approve PR**

   * *I want* to approve a submitted PR.
   * **AC:** Clicking Approve sets status to `approved`; records `approved_by` (app layer) and timestamp; requester sees updated status.

1. **Reject PR with reason**

   * *I want* to reject with a required reason.
   * **AC:** Reject requires non-empty reason; sets status to `rejected`; requester sees reason.

## Admin — Vendors

1. **Create vendor**

    * *As an* admin, *I want* to add a vendor.
    * **AC:** Code and name required; uniqueness enforced; vendor appears in product forms.

1. **Edit vendor**

    * *I want* to update vendor fields.
    * **AC:** Changes persist; existing products keep their vendor_id.

1. **Delete vendor (guarded)**

    * *I want* to delete a vendor that has no products.
    * **AC:** If products exist, deletion is blocked with a message listing dependent products.

## Admin — Products

1. **Create product**

    * *I want* to add a product for a vendor.
    * **AC:** Requires vendor, vendor_part_number, name, price, unit; appears in catalog immediately.

1. **Edit product**

    * *I want* to update product name, price, unit, photo.
    * **AC:** Edits affect future totals; existing PRs recompute total only at submit (per v1 rule).

1. **Delete product (guarded)**

    * *I want* to delete a product only if there are no active requests containing it.
    * **AC:** If any `submitted` PR contains the product, deletion is blocked; guidance shown.

## System / Cross-cutting

1. **Auto-approval threshold (app config)**

    * *As an* admin, *I want* to set an amount under which PRs auto-approve.
    * **AC:** Value is persisted in app config (not DB in v1); submit logic branches correctly; change is audited (who/when) in app logs.

1. **Totals recomputation**

    * *As the* system, *I want* totals computed server-side at submit time.
    * **AC:** Total equals Σ(quantity × current product.price) at submit; drift from draft is displayed to the user before submit.

1. **Authorization guardrails**

    * *As the* system, *I want* to enforce role permissions.
    * **AC:** Only reviewers can approve/reject; only admins can create/edit/delete vendors/products; delete PR guarded by status.

---

# Parking Lot (future enhancements)

* **Product description** field; **search** by description.
* **“Active” flags** for vendors/products; hide from catalog but keep history.
* **Price snapshot** on line items; compute totals from snapshot (eliminates price-drift at approval time).
* **Delivery mode** normalization (enum or lookup).
* **Submitted_date** semantics (set on transition only).
* **Reviewer assignment** and SLAs (queues by team, reminders).
* **Attachments** on PRs (quotes, images).
* **Audit log** table (who did what, when).
* **Per-department auto-approval thresholds**.
