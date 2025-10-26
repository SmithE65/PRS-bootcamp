package app.bootcamp.prs.dto;

public class UserDto {
    private Integer id;
    private Boolean isAdmin;
    private Boolean isReviewer;

    // Getters and Setters
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Boolean getIsAdmin() {
        return isAdmin;
    }

    public void setIsAdmin(Boolean isAdmin) {
        this.isAdmin = isAdmin;
    }

    public Boolean getIsReviewer() {
        return isReviewer;
    }

    public void setIsReviewer(Boolean isReviewer) {
        this.isReviewer = isReviewer;
    }
}