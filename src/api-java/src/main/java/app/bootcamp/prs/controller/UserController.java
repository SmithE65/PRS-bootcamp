package app.bootcamp.prs.controller;

import app.bootcamp.prs.dto.UserDto;
import app.bootcamp.prs.model.AppUser;
import app.bootcamp.prs.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/api/Users")
public class UserController {

    @Autowired
    private UserRepository userRepository;

    @GetMapping
    public List<UserDto> getAllUsers() {
        return userRepository.findAll().stream().map(this::convertToDto).collect(Collectors.toList());
    }

    @PostMapping
    public ResponseEntity<UserDto> createUser(@RequestBody UserDto userDto) {
        AppUser user = convertToEntity(userDto);
        AppUser savedUser = userRepository.save(user);
        return ResponseEntity.ok(convertToDto(savedUser));
    }

    @GetMapping("/{id}")
    public ResponseEntity<UserDto> getUserById(@PathVariable Integer id) {
        return userRepository.findById(id)
                .map(user -> ResponseEntity.ok(convertToDto(user)))
                .orElse(ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<UserDto> updateUser(@PathVariable Integer id, @RequestBody UserDto userDto) {
        return userRepository.findById(id)
                .map(existingUser -> {
                    AppUser updatedUser = convertToEntity(userDto);
                    updatedUser.setId(existingUser.getId());
                    userRepository.save(updatedUser);
                    return ResponseEntity.ok(convertToDto(updatedUser));
                })
                .orElse(ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteUser(@PathVariable Integer id) {
        if (userRepository.existsById(id)) {
            userRepository.deleteById(id);
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }

    private UserDto convertToDto(AppUser user) {
        UserDto dto = new UserDto();
        dto.setId(user.getId());
        dto.setIsAdmin(user.getIsAdmin());
        dto.setIsReviewer(user.getIsReviewer());
        return dto;
    }

    private AppUser convertToEntity(UserDto dto) {
        AppUser user = new AppUser();
        user.setIsAdmin(dto.getIsAdmin());
        user.setIsReviewer(dto.getIsReviewer());
        return user;
    }
}