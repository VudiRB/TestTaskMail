CREATE TABLE MailLog (
  id serial NOT NULL,
  Subject varchar(100) DEFAULT NULL,
  Body varchar(500) DEFAULT NULL,
  Recipient varchar(30) NOT NULL,
  Date date NOT NULL,
  Result varchar(10) NOT NULL,
  FailedMessage text NOT NULL,
  PRIMARY KEY (id)
);