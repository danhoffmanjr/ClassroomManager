using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace App.Infrastructure.Migrations
{
    public partial class AddingStudentLessonJoinDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLesson_Lessons_LessonId",
                table: "StudentLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLesson_Students_StudentId",
                table: "StudentLesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLesson",
                table: "StudentLesson");

            migrationBuilder.RenameTable(
                name: "StudentLesson",
                newName: "StudentLessons");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLesson_LessonId",
                table: "StudentLessons",
                newName: "IX_StudentLessons_LessonId");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Teachers",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Teachers",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Teachers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Teachers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "Teachers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            //migrationBuilder.AddColumn<string>(
            //    name: "User",
            //    table: "Teachers",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Students",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Students",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Students",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Students",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "Students",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            //migrationBuilder.AddColumn<string>(
            //    name: "ImageUrl",
            //    table: "Students",
            //    maxLength: 150,
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "User",
            //    table: "Students",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "User",
            //    table: "LessonSections",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Lessons",
                nullable: true,
                oldClrType: typeof(long));

            //migrationBuilder.AddColumn<string>(
            //    name: "User",
            //    table: "Lessons",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "User",
            //    table: "Courses",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "User",
            //    table: "Attachments",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "User",
            //    table: "Assignments",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLessons",
                table: "StudentLessons",
                columns: new[] { "StudentId", "LessonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessons_Lessons_LessonId",
                table: "StudentLessons",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessons_Students_StudentId",
                table: "StudentLessons",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessons_Lessons_LessonId",
                table: "StudentLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessons_Students_StudentId",
                table: "StudentLessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLessons",
                table: "StudentLessons");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "User",
                table: "LessonSections");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Assignments");

            migrationBuilder.RenameTable(
                name: "StudentLessons",
                newName: "StudentLesson");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLessons_LessonId",
                table: "StudentLesson",
                newName: "IX_StudentLesson_LessonId");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Teachers",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Teachers",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Teachers",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Teachers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Teachers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "Teachers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Students",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Students",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Students",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Students",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine",
                table: "Students",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Lessons",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLesson",
                table: "StudentLesson",
                columns: new[] { "StudentId", "LessonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLesson_Lessons_LessonId",
                table: "StudentLesson",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLesson_Students_StudentId",
                table: "StudentLesson",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
