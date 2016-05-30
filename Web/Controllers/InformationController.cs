﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.DTO;
using BL.Facades;
using Web.Models;

namespace Web.Controllers
{
    public class InformationController : Controller
    {
        StudentFacade studentFacade = new StudentFacade();
        QuestionFacade questionFacade = new QuestionFacade();
        ThematicAreaFacade thematicAreaFacade = new ThematicAreaFacade();
        AnswerFacade answerFacade = new AnswerFacade();
        UserFacade userFacade = new UserFacade();
       
        public ActionResult Redirect()
        {
            return Redirect("http://google.sk");
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult Students()
        {
            var model = userFacade.GetAllStudents();
            return View(model);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult Questions()
        {
            var model = questionFacade.GetAllQuestions();
            return View(model);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult Answers()
        {
            var model = answerFacade.GetAllAnswers();
            return View(model);
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            
            return View();
        }

        /* public ActionResult Students()
         {
             var model = studentFacade.GetAllStudents();
             return View(model);
         }*/
        [HttpPost]
        public ActionResult CreateStudent(StudentDTO student)
        {
            studentFacade.CreateStudent(student);
            return RedirectToAction("Students");
        }

        public ActionResult CreateStudent()
        {
            return View();
        }

        public ActionResult DeleteStudent(int id)
        {
            studentFacade.DeleteStudent(id);
            return RedirectToAction("Students");
        }

        public ActionResult EditStudent(int id)
        {
            var student = studentFacade.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(int id, StudentDTO student)
        {
            var originalStudent = studentFacade.GetStudentById(id);
            originalStudent.FirstName = student.FirstName;
            originalStudent.Surname = student.Surname;
            originalStudent.Email = student.Email;

            studentFacade.UpdateStudent(originalStudent);

            return RedirectToAction("Students");
        }
        public ActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQuestion(QuestionDTO question)
        {
            questionFacade.CreateQuestion(question);
            return RedirectToAction("Questions");
        }

        public ActionResult EditQuestion(int id)
        {
            var question = questionFacade.GetQuestionById(id);
            return View(question);
        }

        [HttpPost]
        public ActionResult EditQuestion(int id, QuestionDTO question)
        {
            var originalQuestion = questionFacade.GetQuestionById(id);
            originalQuestion.Text = question.Text;
            originalQuestion.Points = question.Points;
            originalQuestion.RightAnswers = question.RightAnswers;
            originalQuestion.Explanation = question.Explanation;

            questionFacade.UpdateQuestion(originalQuestion);

            return RedirectToAction("Questions");
        }

        public ActionResult DeleteQuestion(int id)
        {
            questionFacade.DeleteQuestion(id);
            return RedirectToAction("Questions");
        }

        public ActionResult CreateThematicArea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateThematicArea(ThematicAreaDTO area)
        {
            thematicAreaFacade.CreateThematicArea(area);
            return RedirectToAction("ThematicAreas");
        }
    }

}
