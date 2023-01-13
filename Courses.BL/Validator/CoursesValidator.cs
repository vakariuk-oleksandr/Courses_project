using FluentValidation;


namespace Courses.BL
{
    public class CoursesValidator : AbstractValidator<PostCoursesDTO>
    {
        public CoursesValidator()
        {
            RuleFor(x => x.CoursesID).NotEmpty();
            RuleFor(x => x.NameCourses).NotEmpty().Length(3, 45);
        }
    }

}
