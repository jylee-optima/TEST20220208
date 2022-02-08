using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace _3dLineChartTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();

        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {



            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glTranslatef(0f, 0f, 0f);
            Gl.glRotatef(20.0f, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(20.0f, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(1.0f, 0.0f, 0.0f, 1.0f);


            //draw cube
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glColor3f(0.0f, 1.0f, 0.0f);    //green -z축방향
            cubebase();

            Gl.glPushMatrix();
            Gl.glTranslated(1.0f, 0.0f, 0.0f);
            Gl.glRotated(90.0f, 0.0f, 1.0f, 0.0f); //blue + X축방향
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            cubebase();

            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-1.0f, 0.0f, 0.0f);
            Gl.glRotated(-90.0f, 0.0f, 1.0f, 0.0f); //blue - X축방향
            Gl.glColor3f(1.0f, 0.5f, 0.0f);
            cubebase();

            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.0f, 1.0f, 0.0f);
            Gl.glRotated(-90.0f, 1.0f, 0.0f, 0.0f); //Red + Y축방향
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            cubebase();

            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0.0f, -1.0f, 0.0f);
            Gl.glRotated(90.0f, 1.0f, 0.0f, 0.0f); //Yellow - Y축방향
            Gl.glColor3f(1.0f, 1.0f, 0.0f);
            cubebase();


            Gl.glColor3f(1.0f, 0.0f, 1.0f);   //Magenta +Z축
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(-0.5f, -0.5f, 0.5);
            Gl.glVertex3d(0.5f, -0.5f, 0.5);
            Gl.glVertex3d(0.5f, 0.5f, 0.5);
            Gl.glVertex3d(-0.5f, 0.5f, 0.5);
            Gl.glEnd();

            Gl.glPopMatrix();
            Gl.glFlush();








            //Gl.glViewport(0, 0, 176, 208);

            //Gl.glMatrixMode(Gl.GL_PROJECTION);
            //Gl.glLoadIdentity();
            ////Gl.glOrtho(0, 176, 0, 208, -1, 1);

            //Gl.glMatrixMode(Gl.GL_MODELVIEW);
            //Gl.glLoadIdentity();

            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);


            //Gl.glBegin(Gl.GL_LINES);

            ////vertikal
            //Gl.glColor3f(0, 225.1f, 0);
            //Gl.glVertex3f(0, 100, 0.0f);
            //Gl.glVertex3f(85.0f, 400.0f, 0.0f);

            //////Horizontal
            ////Gl.glColor3f(0.0f, 225.0f, 180.0f);
            ////Gl.glVertex3f(95.0f, 100.0f, 0.0f);
            //////Gl.glVertex3f(25000.0f, 400.0f, 0.0f);
            //Gl.glEnd();



        }


        private void cubebase()
        {
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(-0.5f, -0.5f, -0.5f);
            Gl.glVertex3d(-0.5f, 0.5f, -0.5f);
            Gl.glVertex3d(0.5f, 0.5f, -0.5f);
            Gl.glVertex3d(0.5f, -0.5f, -0.5f);
            Gl.glEnd();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, 1920, 1080); //윈도우 크기로 뷰포인트 설정 

            Gl.glMatrixMode(Gl.GL_PROJECTION); //이후 연산은 Projection Matrix에 영향을 준다. 카메라로 보이는 장면 같은거 설정 
            Gl.glLoadIdentity();

            //Field of view angle(단위 degrees), 윈도우의 aspect ratio, Near와 Far Plane설정
            //Gl.gluper gluPerspective(45, (GLfloat)width / (GLfloat)height, 1.0, 100.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW); // glMatrixMode(GL_MODELVIEW); //이후 연산은 ModelView Matirx에 영향을 준다. 객체 조작

        }
    }
}
