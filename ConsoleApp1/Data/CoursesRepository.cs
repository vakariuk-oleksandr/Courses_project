using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;


namespace Courses.Data
{
    public class CoursesRepository : ICoursesrep
    {
        private readonly IDbConnection _connection;
        public CoursesRepository(IDbConnection connection)
        {
            this._connection = connection;
        }
        public async Task<IEnumerable<Courses>> GetAsync()
        {
            return await _connection.QueryAsync<Courses>("select * from Courses");
        }

        public async Task<Courses> GetByIdAsync(string id)
        {
            return await _connection.QuerySingleAsync<Courses>(
                "select * from Courses r where r.CoursesID = @Id",
                new { Id = id });
        }
        public async Task DeleteAsync(string id)
        {
            await _connection.ExecuteAsync(
                "delete from Courses where Courses.CoursesID = @Id",
                new { Id = id });
        }

        public async Task<IEnumerable<Courses>> GetCoursesFromUserAsync(string userId)
        {
            return await _connection.QueryAsync<Courses>(
                "select * from Courses r where r.FromId = @FromId",
                new { FromId = userId });
        }

        public async Task InsertAsync(Courses rating)
        {
            await _connection.ExecuteAsync(
            @"insert into Courses
                (CoursesID, NameCourses, Price, Description) values
                (@CoursesID, @NameCourses, @Price, @Description)",
            new DynamicParameters(rating));
        }
    }
}
