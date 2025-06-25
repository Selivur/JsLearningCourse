using API.Models.User;
using API.Services.Interfaces;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    /// <summary>
    /// Controller for managing system users
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the UserController class
        /// </summary>
        /// <param name="userService">Service for working with users</param>
        public UserController(IUserService userService)
        {
            //todo �������� ������ ������?
            _userService = userService;
        }

        /// <summary>
        /// Gets a list of all users in the system
        /// </summary>
        /// <returns>Collection of users</returns>
        /// <response code="200">Returns the list of users</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Gets a user by their ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User information</returns>
        /// <response code="200">Returns the user information</response>
        /// <response code="404">User not found</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new { message = $"User with ID {id} not found" });

            return Ok(user);
        }

        /// <summary>
        /// Gets a user by their login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>User information</returns>
        /// <response code="200">Returns the user information</response>
        /// <response code="404">User not found</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpGet("login/{login}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponse>> GetUserByLogin(string login)
        {
            var user = await _userService.GetUserByLoginAsync(login);
            if (user == null)
                return NotFound(new { message = $"User with login {login} not found" });

            return Ok(user);
        }

        /// <summary>
        /// Gets a list of students for a specific school
        /// </summary>
        /// <param name="schoolId">School ID</param>
        /// <returns>Collection of students</returns>
        /// <response code="200">Returns the list of students</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpGet("school/{schoolId}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetStudentsBySchool(int schoolId)
        {
            var students = await _userService.GetStudentsBySchoolIdAsync(schoolId);
            return Ok(students);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="request">User creation data</param>
        /// <returns>Created user information</returns>
        /// <response code="201">User successfully created</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponse>> CreateUser(CreateUserRequest request)
        {
            try
            {
                var user = await _userService.CreateUserAsync(request);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Updates user information
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="request">Update data</param>
        /// <returns>Updated user information</returns>
        /// <response code="200">User successfully updated</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="404">User not found</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponse>> UpdateUser(int id, UpdateUserRequest request)
        {
            try
            {
                var user = await _userService.UpdateUserAsync(id, request);
                return Ok(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"User with ID {id} not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Operation result</returns>
        /// <response code="204">User successfully deleted</response>
        /// <response code="404">User not found</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return NotFound(new { message = $"User with ID {id} not found" });

            return NoContent();
        }

        /// <summary>
        /// Creates test users for each role type
        /// </summary>
        /// <returns>List of created users</returns>
        /// <response code="200">Test users successfully created</response>
        /// <response code="400">Error creating users</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpPost("create-test-users")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> CreateTestUsers()
        {
            var testUsers = new List<CreateUserRequest>
            {
                new CreateUserRequest
                {
                    Login = "student1@gmail.com",
                    Password = "student1",
                    Role = UserRole.Student,
                    SchoolId = 1
                },
                new CreateUserRequest
                {
                    Login = "teacher1@gmail.com",
                    Password = "teacher1",
                    Role = UserRole.Teacher,
                    SchoolId = 1
                },
                new CreateUserRequest
                {
                    Login = "student2@gmail.com",
                    Password = "student2",
                    Role = UserRole.Student,
                    SchoolId = 2
                },
                new CreateUserRequest
                {
                    Login = "teacher2@gmail.com",
                    Password = "teacher2",
                    Role = UserRole.Teacher,
                    SchoolId = 2
                },
                new CreateUserRequest
                {
                    Login = "admin1@gmail.com",
                    Password = "admin1",
                    Role = UserRole.Admin,
                    SchoolId = 1
                }
            };

            var createdUsers = new List<UserResponse>();

            foreach (var userRequest in testUsers)
            {
                try
                {
                    var user = await _userService.CreateUserAsync(userRequest);
                    createdUsers.Add(user);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = $"Failed to create user {userRequest.Login}: {ex.Message}" });
                }
            }

            return Ok(createdUsers);
        }

        /// <summary>
        /// Creates a new student user (accessible by teachers)
        /// </summary>
        /// <param name="request">User creation data</param>
        /// <returns>Created user information</returns>
        /// <response code="201">User successfully created</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="401">User is not authenticated</response>
        /// <response code="403">User does not have required permissions</response>
        [HttpPost("createStudent")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult<UserResponse>> CreateUserAsTeacher(CreateUserRequest request)
        {
            try
            {
                var schoolIdClaim = User.FindFirst("SchoolId");
                if (schoolIdClaim == null)
                    return BadRequest(new { message = "SchoolId not found in token" });

                // Override the role to ensure only students can be created
                request.Role = UserRole.Student;
                
                // Use the teacher's school ID
                request.SchoolId = int.Parse(schoolIdClaim.Value);

                var user = await _userService.CreateUserAsync(request);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 