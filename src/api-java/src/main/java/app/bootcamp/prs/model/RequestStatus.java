package app.bootcamp.prs.model;

import jakarta.persistence.*;

@Entity
@Table(name = "request_status")
public class RequestStatus {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @Column(name = "code", nullable = false)
    private String code;

    public Integer getId() {
        return id;
    }

    public String getCode() {
        return code;
    }
}