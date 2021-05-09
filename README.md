# Conference Management System

## Brief
CRUD application created in C# for conferences and sponsors. This project follows the MVC (Model, View, Controller) structure.

### Create a conference
![Create a conference](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/create_conference.png?raw=true)
![Added a conference](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/added_conference.png?raw=true)

### Read a conference
![Read a conference](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/read_conference.png?raw=true)

### Update a conference
![Update a conference](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/update_conference.png?raw=true)
![Updated a conference](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/updated_conference.png?raw=true)

### Delete a conference
![Deleted a conference](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/deleted_conference.png?raw=true)

### Create a sponsor
![Create a sponsor](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/create_sponsor.png?raw=true)
![Created a sponsor](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/created_sponsor.png?raw=true)

### Read a sponsor
![Read a sponsor](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/read_sponsor.png?raw=true)

### Update a sponsor
![Update a sponsor](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/update_sponsor.png?raw=true)
![Updated a sponsor](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/updated_sponsor.png?raw=true)

### Delete a sponsor
![Deleted a sponsor](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/deleted_sponsor.png?raw=true)

## Technologies
| Dependency | Version |
| --- | ----------- |
| .NET Framework | 5.0.202 |

## Backlog
Below is a screenshot of the backlog containing the epics, user stories, and tasks for this project. 
![Backlog](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/backlog.png?raw=true)
To view all tasks associated with the user stories, please follow [this link](https://andra-vasilcoiu.atlassian.net/jira/software/projects/CN/boards/3/backlog?issueParent=10017%2C10020%2C10051&selectedIssue=CN-2).

## Components

### Models
* Conference
* Sponsor
* AddConferenceBindingModel
* AddSponsorBindingModel
* ConferenceViewModel
* SponsorView Model

### Views
* Home
* Conferences
* Sponsors

### Controllers
* Home Controller
* Conference Controller
* Sponsors Controller

## Database Structure
![Database](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/db_diagram.png?raw=true)

## Risk Assessment
Pictured below is an entity relationship diagram (ERD) showing the structure of the database.
![Risk Assessment](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/risk_assessment.png?raw=true)
As shown in the ERD, the app models a one-to-many relationship between Conference entities and Sponsor entities.

### Testing
Xunit was used to unit test the .NET Core code.
A report was generated in the form of an HTML file from a "coverage.cobertura.xml" file.
![Coverage report summary](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/coverage_report_summary.png?raw=true)
![Coverage report details](https://github.com/Andra1609/ConferenceApp/blob/main/readme_img/coverage_report_details.png?raw=true)

## Future work
* Creating an Angular based front-end
* Testing the Views

### Acknowledgements
This project was created as part of QA Academy training.

### License
This project is licensed under the terms of the MIT license.