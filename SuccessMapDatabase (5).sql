SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema SuccessMapDatabase
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema SuccessMapDatabase
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `SuccessMapDatabase` DEFAULT CHARACTER SET utf8 ;
USE `SuccessMapDatabase` ;

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`College`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`College` (
  `CollegeID` INT NOT NULL,
  `CollegeName` VARCHAR(45) NULL,
  `Abbr` VARCHAR(45) NULL,
  PRIMARY KEY (`CollegeID`),
  UNIQUE INDEX `CollegeID_UNIQUE` (`CollegeID` ASC))
ENGINE = InnoDB;

--
-- Dumping data for table `college`
--

INSERT INTO `college` (`CollegeID`, `CollegeName`, `Abbr`) VALUES
(1, 'Liberal Arts', 'CLA'),
(2, 'Herberger Business School', 'HBS'),
(3, 'School of Public Affairs', 'SOPA'),
(4, 'College of Science and Engineering', 'COSE'),
(5, 'School of Education', 'SOE'),
(6, 'School of Health and Human Services', 'SHHS');

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`Department`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`Department` (
  `DepartmentID` INT NOT NULL,
  `DeptName` VARCHAR(45) NULL,
  `CollegeID` INT NULL,
  PRIMARY KEY (`DepartmentID`),
  UNIQUE INDEX `DepartmentID_UNIQUE` (`DepartmentID` ASC),
  INDEX `CollegeID_idx` (`CollegeID` ASC),
  CONSTRAINT `CollegeID`
    FOREIGN KEY (`CollegeID`)
    REFERENCES `SuccessMapDatabase`.`College` (`CollegeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`DepartmentID`, `DeptName`, `CollegeID`) VALUES
(1, 'Biology', 4),
(2, 'Chemistry & Biochemistry', 4),
(3, 'Physics & Astronomy', 4),
(4, 'Mathematics & Statistics', 4),
(5, 'Applied Education in the MedTech Industry', 4),
(6, 'Atmospheric and Hydrologic Sciences', 4),
(7, 'Computer Science & Information Technology', 4),
(8, 'Electrical & Computer Engineering', 4),
(9, 'Enironment & Technological Studies', 4),
(10, 'Mechanical & Manufacturing Engineering', 4);

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`Program`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`Program` (
  `PrgmID` INT NOT NULL,
  `PrgmName` VARCHAR(45) NULL,
  `Abbr` VARCHAR(45) NULL,
  `DeptID` INT NULL,
  PRIMARY KEY (`PrgmID`),
  INDEX `DeptID_idx` (`DeptID` ASC),
  CONSTRAINT `DeptID`
    FOREIGN KEY (`DeptID`)
    REFERENCES `SuccessMapDatabase`.`Department` (`DepartmentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

--
-- Dumping data for table `program`
--

INSERT INTO `program` (`PrgmID`, `PrgmName`, `Abbr`, `DeptID`) VALUES
(1, 'Computer Science', 'CSCI', 7),
(2, 'Cyber Security', 'CNA', 7),
(3, 'Software Engineering', 'SE', 7),
(4, 'Computer Science (MS)', 'CSCI MS', 7);

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`SuccessMap`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`SuccessMap` (
  `SMID` INT NOT NULL,
  `SMName` VARCHAR(45) NULL,
  `PrgmID` INT NULL,
  PRIMARY KEY (`SMID`),
  INDEX `PrgmID_idx` (`PrgmID` ASC),
  CONSTRAINT `PrgmID`
    FOREIGN KEY (`PrgmID`)
    REFERENCES `SuccessMapDatabase`.`Program` (`PrgmID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

--
-- Dumping data for table `successmap`
--

INSERT INTO `successmap` (`SMID`, `SMName`, `PrgmID`) VALUES
(1, 'Software Engineering', 3);

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`Year`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`Year` (
  `Year` INT NOT NULL,
  `Class` VARCHAR(45) NULL,
  PRIMARY KEY (`Year`),
  UNIQUE INDEX `Year_UNIQUE` (`Year` ASC))
ENGINE = InnoDB;

--
-- Dumping data for table `year`
--

INSERT INTO `year` (`Year`, `Class`) VALUES
(1, 'Freshman'),
(2, 'Sophomore'),
(3, 'Junior'),
(4, 'Senior'),
(5, 'Senior');

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`Semester`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`Semester` (
  `SemesterID` INT NOT NULL,
  `Year` INT NULL,
  `SemesterName` VARCHAR(45) NULL,
  PRIMARY KEY (`SemesterID`),
  UNIQUE INDEX `SemesterID_UNIQUE` (`SemesterID` ASC),
  INDEX `Year_idx` (`Year` ASC),
  CONSTRAINT `Year`
    FOREIGN KEY (`Year`)
    REFERENCES `SuccessMapDatabase`.`Year` (`Year`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

--
-- Dumping data for table `semester`
--

INSERT INTO `semester` (`SemesterID`, `Year`, `SemesterName`) VALUES
(1, 1, 'Fall'),
(2, 1, 'Spring'),
(3, 2, 'Fall'),
(4, 2, 'Spring'),
(5, 3, 'Fall'),
(6, 3, 'Spring'),
(7, 4, 'Fall'),
(8, 3, 'Summer'),
(9, 4, 'Spring'),
(10, 1, 'Summer'),
(11, 2, 'Summer'),
(12, 4, 'Summer');

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`Objective`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`Objective` (
  `ObjID` VARCHAR(45) NOT NULL,
  `ObjName` VARCHAR(45) NULL,
  `Type` VARCHAR(45) NULL,
  `Link` VARCHAR(45) NULL,
  `Description` VARCHAR(200) NULL,
  PRIMARY KEY (`ObjID`))
ENGINE = InnoDB;

--
-- Dumping data for table `objective`
--

INSERT INTO `objective` (`ObjID`, `ObjName`, `Type`, `Link`, `Description`) VALUES
('41', 'HuskiesHack', 'activity', 'https://huskiesconnect.stcloudstate.edu/event', 'HuskiesHack is a 24-hour event of solving real-world problems with a team of 4 students. Students from all backgrounds, majors, and levels are encouraged to apply. Talented student developers are goin'),
('42', 'Hackathons', 'activity', 'https://en.wikipedia.org/wiki/Hackathon', 'A hackathon (also known as a hack day, hackfest or codefest; a portmanteau of hacking marathon) is a design sprint-like event; often, in which computer programmers and others involved in software deve'),
('43', 'Husky Invents', 'activity', 'https://today.stcloudstate.edu/students-take-', ''),
('44', 'Guest Speaker', 'activity', 'https://www.stcloudstate.edu/powerindiversity', 'Guest speaker '),
('46', 'Mock Interview', 'activity', 'https://huskiesconnect.stcloudstate.edu/event', 'Mock interviews are a unique opportunity to have a practice interview with an experienced recruiter and get invaluable feedback and advice. To sign up, click on Handshake at www.stcloudstate.edu/caree'),
('SCSU Goal Area', 'SCSU Goal Area', 'course goalarea', 'https://catalog.stcloudstate.edu/Catalog/View', 'Goal 1: Communication  (2 courses)\r\nGoal 2: Critical Thinking  (1 course)\r\nGoal 3: Natural Sciences (Minimum of two courses, no more than 4 credits)\r\nGoal 4: Mathematical/Logical Reasoning  (1 course\r'),
('CMST 341', 'CMST 341 Communication in the Workplace', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Theoretical understanding of the contemporary workplace as a system of human forces and communication. Interpersonal communication skills for productive worklife. Professional presentations.'),
('CSCI 201', 'CSCI 201 Computer Science 1', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Data abstraction, elementary data structures, and dynamic data structures. Sorting and searching. Error handling and recovery. Time and space analysis of algorithms and big-O notation. Linked and sequ'),
('CSCI 220', 'CSCI 220 Computer Architecture I', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'CPU architecture, number systems, digital circuit design, assembly language programming, VHDL programming.'),
('CSCI 301', 'CSCI 301 Computer Science 2', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Recursion and recurrence. Trees, binary trees, 2/3 trees, directed and undirected graphs, searching and sorting, program layering. Sequential file processing, indexed files, and hashing techniques.'),
('CSCI 430', 'CSCI 430 Object-Oriented Software Development', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Techniques for identifying and specifying objects, object classes and operations in designing software. Development of a major project using object-oriented analysis, design and programming techniques'),
('CSCI 450', 'CSCI 450 Computer Graphics', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Algorithms, data structures and techniques for generating graphics. Graphics hardware, display primitives, geometric transformations, perspective projection, clipping and user interaction.'),
('ENGL 332', 'ENGL 332 Writing for the Professions', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Rhetorical situations, purposes, audience and ethical issues in workplace writing genres. Collaboration processes, layout/format conventions, clarity and correctness. May include oral presentations, u'),
('GENG 101', 'GENG 101 Ethics and the Engineering Professi', 'course goalarea', 'https://catalog.stcloudstate.edu/Catalog/View', 'Major ethical theories; sources of ethics; professional responsibilities; social impact of engineering ethics; teamwork skills; design; engineering careers. '),
('MATH 221', 'MATH 221 Calculus I', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Limits, continuity, differentiation, applications of derivatives, integration. Prereq.: 115, or 112 and 113, or high school advanced algebra and trigonometry with a satisfactory math placement score. '),
('MATH 222', 'MATH 222 Calculus II', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Integration techniques and applications, inverse functions, topics in analytic geometry, sequences and series, improper integrals, plane curves. '),
('MATH 271', 'MATH 271 Discrete Mathematics', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Formal logic, sets, relations, functions, introduction to number theory and graph theory, basic counting principle, discrete probability, applications. '),
('MATH 304', 'MATH 304 Tools of Mathematical Reasoning', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Techniques of proof reading and writing; review of discrete mathematics; computer representation of numbers; induction; automata and grammars; computational complexity; formal logic; sets and transfin'),
('MATH 312', 'MATH 312 Linear Algebra', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Matrices, matrix operations, systems of linear equations, determinants, geometry of R-n, vector spaces, subspaces, linear transformations, inner products, eigenvalues. '),
('MATH 320', 'MATH 320 Multivariable Calculus for Engineers', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Vectors, functions of several variables, gradients, multiple integrals, applications.'),
('SE 210', 'SE 210 Operating Systems and Applications ', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Operating systems design, concurrent processes, inter-process communication, synchronization, scheduling, resource allocation, and memory management. Mobile operating systems (Android and iOS) and the'),
('SE 211', 'SE 211 Introduction to Database Systems', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Database management, design, and implementation. Database theory, data modeling, relational model concepts, data normalization, relational algebra, Structured Query Language (SQL), database design. Us'),
('SE 221', 'SE 221 Introduction to Computer Networking ', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Design and management of computer networks. Servers, routers, bridges, gateways, transmission media, communications protocols, network security, and performance tuning.'),
('SE 231', 'SE 231 Introduction to Computer Security', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Computer security and applied cryptography, software vulnerability analysis, defense, exploitation, reverse engineering, networking and wireless security.'),
('SE 240', 'SE 240 Introduction to Software Engineering', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Software process models, software life-cycle (planning, requirements, design, construction, quality assurance, and maintenance), software security, Software Engineering Code of Ethics and Professional'),
('SE 276', 'SE 276 Introduction to Mobile Applications', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Mobile application development frameworks; architecture, design and engineering issues, techniques, methodologies for mobile application development'),
('SE 340', 'SE 340 Applied Undergraduate Research', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Advanced applied research topics in software engineering.'),
('SE 341', 'SE 341 Applied Undergraduate Research', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Advanced applied research topics in software engineering.'),
('SE 350', 'SE 350 Software Engineering and Human Compute', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Concepts of human-computer interaction, user-centered design, heuristic evaluation, and evaluation of software usability.'),
('SE 412', 'SE 412 Data Mining for Software Engineering', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Mining interesting information from large data sets. Statistical analysis and machine learning, data mining concepts and techniques, data representation and their similarity/dissimilarity measures, da'),
('SE 413', 'SE 413 Big Data Organization and Management', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Data analytics concepts and techniques. Big-data features and representations, data collection and sampling, predicative modeling, frequent patterns, social networks analysis, data benchmarking and pr'),
('SE 444', 'SE 444 Internship', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Complete 450 hours working on software engineering projects in a professional environment.'),
('SE 460', 'SE 460 Software Analysis', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Software requirements analysis, requirement specification, elicitation, verification and validation, quality assurance metrics.'),
('SE 465', 'SE 465 Software Design', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Formal methods of software analysis/design. Design patterns, standard middle-ware, software architecture including object/function oriented design. Design quality assurance management. Reverse enginee'),
('SE 466', 'SE 466 Game Development', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Game design teams and processes, Game scripting and programming, Game data structures and algorithms, Artificial intelligence, Play testing'),
('SE 470', 'SE 470 Software Quality', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Quality assurance concepts and their role in software development. Planning, validation and verification, testing, configuration and delivery management.'),
('SE 475', 'SE 475 Software Construction', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Implementation and testing, state-based, table-driven, and low-level design of software. Design patterns and refactoring. Analysis of designs based on quality criteria, performance and maintainability'),
('SE 477', 'SE 477 Mobile Application Development', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Design of Mobile Applications. Mobile application frameworks, advanced mobile user-interface interactions involving sensors, event handling, data management and network communication.'),
('SE 478', 'SE 478 Introduction to Enterprise Resource Pl', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Enterprise system integration, process management and workflow, supply chain management, customer relationship management.'),
('SE 479', 'SE 479 Information Technology Transformation', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Technological and managerial aspects of information technology. Change management and transformation. Process review and risk management.'),
('SE 480', 'SE 480 Software Project Management', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Use knowledge areas and develop procedures, skills, and resources for successful management of software projects.'),
('SE 482', 'SE 482 Computer Animation and Visualization', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Computer animation logic and programming. Data representation and visualization. Motion capture technologies. Optimization and physical animation techniques.'),
('SE 490', 'SE 490 Software Project I', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'First part of a group project/research course. Pursue projects or research with faculty adviser, within an area of Software Engineering. '),
('SE 491', 'SE 491 Software Project II', 'course programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Second of a full year, group project/research course. Students pursue projects or research, with a faculty adviser, within an area of Software Engineering. '),
('STAT 321', 'STAT 321 Statistical Methods II', 'course elective', 'https://catalog.stcloudstate.edu/Catalog/View', 'Statistical methods for analyzing data beyond Statistical Methods I. Modeling data using simple and multiple regression, and one- and two-way analysis of variance. Transformations, model selection, mu'),
('STAT 353', 'STAT 353 Statistical Methods I for Engineerin', 'coure programcore', 'https://catalog.stcloudstate.edu/Catalog/View', 'Probability distributions; introduction to statistical methods, including hypothesis testing and confidence intervals, one-way anova, simple linear regression, quality control basics; applications, an');

-- --------------------------------------------------------

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`SuccessCategory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`SuccessCategory` (
  `CategoryID` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`CategoryID`))
ENGINE = InnoDB;

--
-- Dumping data for table `successcategory`
--

INSERT INTO `successcategory` (`CategoryID`, `Name`) VALUES
(1, 'Soft Skills'),
(2, 'Life Long Learning'),
(3, 'Hard Skills'),
(4, 'Fundamental Knowledge & Concepts'),
(5, 'Citizenship');

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`SuccessObjectiveClassification`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`SuccessObjectiveClassification` (
  `ClassificationID` INT NOT NULL,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`ClassificationID`))
ENGINE = InnoDB;

--
-- Dumping data for table `successobjectiveclassification`
--

INSERT INTO `successobjectiveclassification` (`ClassificationID`, `Name`) VALUES
(1, 'Lab & Experiential Learning'),
(2, 'Read Search & Discuss'),
(3, 'Group-base Semester Long Project'),
(4, 'Research Activities'),
(5, 'Professional Work Experiences');

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`SuccessObjectiveMapping`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`SuccessObjectiveMapping` (
  `MappingID` INT NOT NULL,
  `ObjID` VARCHAR(45) NOT NULL,
  `SemesterID` INT NULL,
  `CategoryID` INT NULL,
  `ClassificationID` INT NULL,
  `SMID` INT NULL,
  `Weight` INT NULL,
  INDEX `SemesterID_idx` (`SemesterID` ASC),
  INDEX `CategoryID_idx` (`CategoryID` ASC),
  INDEX `ClassificationID_idx` (`ClassificationID` ASC),
  INDEX `SMID_idx` (`SMID` ASC),
  PRIMARY KEY (`MappingID`),
  CONSTRAINT `ObjID`
    FOREIGN KEY (`ObjID`)
    REFERENCES `SuccessMapDatabase`.`Objective` (`ObjID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `SemesterID`
    FOREIGN KEY (`SemesterID`)
    REFERENCES `SuccessMapDatabase`.`Semester` (`SemesterID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `CategoryID`
    FOREIGN KEY (`CategoryID`)
    REFERENCES `SuccessMapDatabase`.`SuccessCategory` (`CategoryID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `ClassificationID`
    FOREIGN KEY (`ClassificationID`)
    REFERENCES `SuccessMapDatabase`.`SuccessObjectiveClassification` (`ClassificationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `SMID`
    FOREIGN KEY (`SMID`)
    REFERENCES `SuccessMapDatabase`.`SuccessMap` (`SMID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

--
-- Dumping data for table `successobjectivemapping`
--

INSERT INTO `successobjectivemapping` (`MappingID`, `ObjID`, `SemesterID`, `CategoryID`, `ClassificationID`, `SMID`, `Weight`) VALUES
(1, 'SE 240', 2, 3, 1, 1, 7),
(2, 'SE 221', 1, 3, 3, 1, 7),
(3, 'CSCI 201', 1, 4, NULL, 1, 5),
(4, 'CSCI 301', 2, 4, 1, 1, 6),
(5, 'SE 210', 2, 3, NULL, 1, 8),
(6, 'SE 211', 3, 3, NULL, 1, 8),
(7, 'GENG 101', 1, 5, 3, 1, 3),
(8, 'SE 231', 2, 2, 2, 1, 7),
(9, 'SE 340', 3, 2, 4, 1, 8),
(10, 'SE 341', 4, 2, 4, 1, 9),
(11, 'SE 350', 4, 3, 3, 1, 7),
(12, 'SE 444', 8, 1, 5, 1, 10),
(13, 'SE 460', 5, 3, 3, 1, 9),
(14, 'SE 465', 5, 3, 3, 1, 9),
(15, 'SE 470', 6, 3, 3, 1, 9),
(16, 'SE 475', 6, 3, 3, 1, 9),
(17, 'CSCI 430', 6, 4, 3, 1, 6),
(18, 'SE 480', 7, 1, 3, 1, 8),
(19, 'SE 490', 7, 1, 3, 1, 9),
(20, 'SE 491', 9, 1, 3, 1, 9),
(21, 'MATH 221', 1, 4, NULL, 1, 4),
(22, 'MATH 271', 1, 4, NULL, 1, 4),
(23, 'MATH 312', 3, 4, NULL, 1, 4),
(24, 'STAT 353', 4, 4, NULL, 1, 4),
(25, 'ENGL 332', 5, 1, NULL, 1, 6),
(26, 'CMST 341', 5, 1, NULL, 1, 6),
(27, 'CSCI 220', 4, 4, NULL, 1, 7),
(28, 'CSCI 450', 5, 3, 3, 1, 5),
(29, 'SE 412', 6, 3, 3, 1, 8),
(30, 'SE 413', 7, 3, 3, 1, 8),
(31, 'SE 466', 5, 3, 2, 1, 6),
(32, 'SE 276', 4, 3, 1, 1, 8),
(41, '41', 1, 1, NULL, 1, 1),
(42, '42', 2, 1, NULL, 1, 1),
(43, '43', 3, 1, NULL, 1, 1),
(44, 'SE 221', 1, 1, 2, 1, 7),
(45, 'SE 221', 1, 2, 2, 1, 7),
(46, 'SE 231', 2, 1, 2, 1, 6),
(47, 'SE 231', 2, 3, 1, 1, 6),
(48, 'SE 340', 3, 1, 3, 1, 7),
(49, 'SE 341', 4, 1, 3, 1, 7),
(50, 'SE 350', 4, 1, 3, 1, 8),
(51, 'SE 350', 4, 2, 3, 1, 8),
(52, 'SE 465', 5, 2, 2, 1, 9),
(53, 'SE 470', 6, 2, 2, 1, 9),
(54, 'SE 490', 7, 2, 4, 1, 10),
(55, 'SE 491', 9, 2, 4, 1, 10),
(56, 'SE 478', 9, 3, 3, 1, 7),
(57, 'SCSU Goal Area', 3, 4, 2, 1, 3),
(58, 'SCSU Goal Area', 4, 4, 2, 1, 3),
(59, 'SCSU Goal Area', 10, 4, 2, 1, 3);

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`StudentSuccessMap`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`StudentSuccessMap` (
  `StarID` VARCHAR(8) NOT NULL,
  `PrgmID` INT NOT NULL,
  PRIMARY KEY (`StarID`, `PrgmID`),
  INDEX `PrgmID_idx` (`PrgmID` ASC),
  CONSTRAINT `Student_PrgmID`
    FOREIGN KEY (`PrgmID`)
    REFERENCES `SuccessMapDatabase`.`Program` (`PrgmID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

--
-- Dumping data for table `StudentSuccessMap`
--

INSERT INTO `StudentSuccessMap` (`StarID`, `PrgmID`) VALUES
('xh7102oj', 3);

-- -----------------------------------------------------
-- Table `SuccessMapDatabase`.`CompletedObjective`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SuccessMapDatabase`.`CompletedObjective` (
  `StarID` VARCHAR(8) NOT NULL,
  `ObjID` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`StarID`, `ObjID`),
  INDEX `ObjID_idx` (`ObjID` ASC),
  CONSTRAINT `Completed_ObjID`
    FOREIGN KEY (`ObjID`)
    REFERENCES `SuccessMapDatabase`.`Objective` (`ObjID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

--
-- Dumping data for table `StudentSuccessMap`
--

INSERT INTO `CompletedObjective` (`StarID`, `ObjID`) VALUES
('xh7102oj', 'SE 240'),
('xh7102oj', 'SE 221'),
('xh7102oj', 'CSCI 201'),
('xh7102oj', 'CSCI 301'),
('xh7102oj', 'SE 210'),
('xh7102oj', 'SE 211'),
('xh7102oj', 'GENG 101'),
('xh7102oj', 'SE 231'),
('xh7102oj', 'SE 340'),
('xh7102oj', 'SE 350'),
('xh7102oj', 'CSCI 430'),
('xh7102oj', 'MATH 221'),
('xh7102oj', 'MATH 271'),
('xh7102oj', 'MATH 312'),
('xh7102oj', 'STAT 353'),
('xh7102oj', 'CMST 341'),
('xh7102oj', 'CSCI 220'),
('xh7102oj', 'SE 276');

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;