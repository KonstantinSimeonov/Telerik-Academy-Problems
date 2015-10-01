<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

  <xsl:template match="/Telegwarts">
    <html>
      <style>
        dd {
        padding-left: 5px;
        color: black;
        padding-top: 0px;
        padding-bottom: 0px;
        }

        dl {
        font-size: 18px;
        padding-left: 5px;
        }

        dt {
        display: inline-block;
        background-color: white;
        border-radius: 10px;
        font-size: 22px;
        margin-top: 10px;
        font-style: italic;
        }

        .form {
        vertical-align: top;
        margin-left: 10px;
        display: inline-block;
        width: 300px;
        border: 1px solid #9efaff;
        background-color: #cecece;
        border-radius: 5px;
        margin-top: 10px;
        margin-bottom: 10px;
        }

        .exam-form {
        border-bottom: 2px solid gray;
        margin-top: 5px;
        }
        
        .tutors-container table {
        border: 1px solid gray;
        width: 700px;
        }
        
        thead {
        font-weight: bold;
        }
        
        tbody td {
        border: 1px solid gray;
        }
        
      </style>
      <body>
        <h3>Prodigies: </h3>
        <div>
          <xsl:for-each select="students/student">
            <div class="form">
              <dl>
                <dt>
                  Name:
                </dt>
                <dd>
                  <xsl:value-of select="name"/>
                </dd>
                <dt>
                  Gender:
                </dt>
                <dd>
                  <xsl:value-of select="sex"/>
                </dd>
                <dt>
                  Birth date:
                </dt>
                <dd>
                  <xsl:value-of select="birthdate"/>
                </dd>
                <dt>
                  Phone:
                </dt>
                <dd>
                  <xsl:value-of select="phone"/>
                </dd>
                <dt>
                  Email:
                </dt>
                <dd>
                  <xsl:value-of select="email"/>
                </dd>
                <dt>
                  Current Course:
                </dt>
                <dd>
                  <xsl:value-of select="course"/>
                </dd>
                <dt>
                  Specialized in:
                </dt>
                <dd>
                  <xsl:value-of select="specialty"/>
                </dd>
                <dt>
                  Faculty Number:
                </dt>
                <dd>
                  <xsl:value-of select="facultynumber"/>
                </dd>
                <dt>
                  Exams participation:
                </dt>
                <dd>
                  <dl>
                    <xsl:for-each select="exams/exam">
                      <div class="exam-form">
                        <dt>Course: </dt>
                        <dd>
                          <xsl:value-of select="name"/>
                        </dd>
                        <dt>Tutor: </dt>
                        <dd>
                          <xsl:value-of select="tutor/name"/>
                        </dd>
                        <dt>Score: </dt>
                        <dd>
                          <xsl:value-of select="score"/>
                        </dd>
                      </div>

                    </xsl:for-each>
                  </dl>
                </dd>
              </dl>

            </div>
          </xsl:for-each>
        </div>
        <div class="tutors-container">
          <h3>Teachers: </h3>
          
          <table>
            <thead>
                <tr>
                  <td>Name</td>
                  <td>Enrolled in</td>
                  <td>Endorsements</td>
                </tr>
            </thead>
            <tbody>
              <xsl:for-each select="students/student/exams/exam/tutor">
                <tr>
                  <td>
                    <xsl:value-of select="name"/>
                  </td>
                  <td>
                    <xsl:value-of select="enrollment/year"/>
                  </td>
                  <td class="endorsement">
                    <xsl:value-of select="enrollment/endorsement"/>
                  </td>
                </tr>
              </xsl:for-each>
            </tbody>
            
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>