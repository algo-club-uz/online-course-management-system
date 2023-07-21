# Online Course Management System
This project includes several microservices and is being writing by my team. My team includes back_end, front_end, mobile developers. It helps to upload contents which belong to IT cources and science. Every person can use this site with free and paid. I mant that some courses will be free and some of them will be paid. I think, it will be great :)
### Identity.API
```C#
Identity 

  GET    users
  POST   users
  GET    users/{user_id}
  PUT    users/{user_id}
  DELETE users/{user_id}

```

### Courses.API
```C#
Courses 
  GET    courses
  POST   courses
  GET    courses/{course_id}
  PUT    courses/{course_id}
  DELETE courses/{course_id}


  GET    users/{user_id}/courses/{course_id}/user_courses
  POST   users/{user_id}/courses/{course_id}/user_courses
  GET    users/{user_id}/courses/{course_id}/user_courses/{user_course_id}
  PUT    users/{user_id}/courses/{course_id}/user_courses/{user_course_id}
  DELETE users/{user_id}/courses/{course_id}/user_courses/{user_course_id}

  GET    courses/{course_id}/contents
  POST   courses/{course_id}/contents
  GET    courses/{course_id}/contents/{content_id}
  PUT    courses/{course_id}/contents/{content_id}
  DELETE courses/{course_id}/contents/{content_id}

  GET    courses/{course_id}/contents/{content_id}/datas
  POST   courses/{course_id}/contents/{content_id}/datas
  GET    courses/{course_id}/contents/{content_id}/datas/{data_id}
  PUT    courses/{course_id}/contents/{content_id}/datas/{data_id}
  DELETE courses/{course_id}/contents/{content_id}/datas/{data_id}

```


