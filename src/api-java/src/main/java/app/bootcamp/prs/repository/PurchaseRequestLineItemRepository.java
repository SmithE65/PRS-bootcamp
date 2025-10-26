package app.bootcamp.prs.repository;

import app.bootcamp.prs.model.PurchaseRequestLineItem;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface PurchaseRequestLineItemRepository extends JpaRepository<PurchaseRequestLineItem, Integer> {
}