use dolansoft

CREATE TABLE ROLES (
	ROLE_TYPE		VARCHAR(30)	PRIMARY KEY
);

CREATE TABLE USERS (
	USERS_ID		INT	PRIMARY KEY,
	ROLE_TYPE		VARCHAR(30),
	EMAIL			VARCHAR(50),
	USERNAME		VARCHAR(30),
	SURNAME			VARCHAR(30),
	LASTNAME		VARCHAR(30),
	PASSWORDS		VARCHAR(30),
	FOREIGN KEY (ROLE_TYPE) REFERENCES ROLES(ROLE_TYPE)
);

CREATE TABLE PROJECT(
	PROJECT_ID		INT	PRIMARY KEY,
	STARTING_DATE		DATE,
	FINAL_DATE		DATE,
	DESCRIPTIONS		VARCHAR(100),
	PROJECT_NAME		VARCHAR(30),
	LEADER_ID		INT,
	FOREIGN KEY (LEADER_ID) REFERENCES USERS(USERS_ID)
);

ALTER TABLE USERS ADD PROJECT_ID INT NULL;
ALTER TABLE USERS ADD CONSTRAINT FL_PID FOREIGN KEY (PROJECT_ID) REFERENCES PROJECT(PROJECT_ID);

CREATE TABLE BACKLOG (
	BACKLOG_ID		INT,
	PROJECT_ID		INT,
	PRIMARY KEY (BACKLOG_ID, PROJECT_ID),
	FOREIGN KEY (PROJECT_ID) REFERENCES PROJECT(PROJECT_ID)
);

CREATE TABLE SPRINT(
	SPRINT_ID		INT,
	BACKLOG_ID		INT,
	PROJECT_ID		INT,
	STARTING_DATE		DATE,
	FINAL_DATE		DATE,
	PRIMARY KEY (SPRINT_ID, BACKLOG_ID, PROJECT_ID),
	FOREIGN KEY (BACKLOG_ID, PROJECT_ID) REFERENCES BACKLOG(BACKLOG_ID, PROJECT_ID)
);

CREATE TABLE USER_STORY(
	STORY_ID		INT,
	BACKLOG_ID		INT,
	PROJECT_ID		INT,
	SPRINT_ID		INT,
	PRIORITIES		INT,
	CLIENT_ROLE		VARCHAR(30),
	ESTIMATION		INT, /* D�AS */
	REASON			VARCHAR(150),
	FUNCTIONALITY		VARCHAR(150),
	PRIMARY KEY (STORY_ID, BACKLOG_ID, PROJECT_ID),
	FOREIGN KEY (SPRINT_ID, BACKLOG_ID, PROJECT_ID) REFERENCES SPRINT(SPRINT_ID, BACKLOG_ID, PROJECT_ID)
);

CREATE TABLE SCENARIO(
	NUMBER			INT,
	STORY_ID		INT,
	BACKLOG_ID		INT,
	PROJECT_ID		INT,
	ACCEPTANCE_CRITERIA	VARCHAR(30),
	CONTEXT			VARCHAR(300),
	EVENTZ			VARCHAR(300),
	RESULT			VARCHAR(300),
	PRIMARY KEY (NUMBER, STORY_ID, BACKLOG_ID, PROJECT_ID),
	FOREIGN KEY (STORY_ID, BACKLOG_ID, PROJECT_ID) REFERENCES USER_STORY(STORY_ID, BACKLOG_ID, PROJECT_ID)
);

CREATE TABLE TASK(
	TASK_ID			INT,
	STORY_ID		INT,
	RESPONSIBLE_ID		INT,
	BACKLOG_ID		INT,
	PROJECT_ID		INT,
	DESCRIPTIONS		VARCHAR(300),
	ESTIMATED_TIME		INT,
	PRIMARY KEY (TASK_ID, STORY_ID, BACKLOG_ID, PROJECT_ID),
	FOREIGN KEY (STORY_ID, BACKLOG_ID, PROJECT_ID) REFERENCES USER_STORY(STORY_ID, BACKLOG_ID, PROJECT_ID),
	FOREIGN KEY (RESPONSIBLE_ID) REFERENCES USERS(USERS_ID)
);

CREATE TABLE PERMISSION (
	PERMISSION_ID		INT PRIMARY KEY,
	DESCRIPTIONS		VARCHAR(30),
);

CREATE TABLE MILESTONE(
	MILESTONE_ID		INT,
	TASK_ID			INT,
	STORY_ID		INT,
	BACKLOG_ID		INT,
	PROJECT_ID		INT,
	PROGRESS		INT,
	DATES			DATE,
	PRIMARY KEY (MILESTONE_ID, TASK_ID, STORY_ID, BACKLOG_ID, PROJECT_ID),
	FOREIGN KEY (TASK_ID, STORY_ID, BACKLOG_ID, PROJECT_ID) REFERENCES TASK(TASK_ID, STORY_ID, BACKLOG_ID, PROJECT_ID)
);

CREATE TABLE ENCAPSULATES(
	ROLE_TYPE		VARCHAR(30),
	PERMISSION_ID	INT,
	PRIMARY KEY (ROLE_TYPE, PERMISSION_ID),
	FOREIGN KEY (ROLE_TYPE) REFERENCES ROLES(ROLE_TYPE),
	FOREIGN KEY (PERMISSION_ID) REFERENCES PERMISSION(PERMISSION_ID)
);

/*
DROP TABLE ENCAPSULATES;
DROP TABLE MILESTONE;
DROP TABLE PERMISSION;
DROP TABLE TASK;
DROP TABLE PROJECT_USERS;
DROP TABLE SCENARIO;
DROP TABLE USER_STORY;
DROP TABLE SPRINT;
DROP TABLE BACKLOG;
DROP TABLE PROJECT;
DROP TABLE USERS;
DROP TABLE ROLES;
*/