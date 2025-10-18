Imports System.Drawing.Drawing2D

Public Class main

    Private Structure structSnake
        Dim rect As Rectangle
        Dim x As Integer
        Dim y As Integer
    End Structure

    Private Enum Direction
        Rightward
        Downward
        Leftward
        Upward
    End Enum

    Private Const INITIAL_SNAKE_RECT_COUNT As Integer = 15
    Private Const COLUMN_COUNT As Integer = 65
    Private Const ROW_COUNT As Integer = 47

    Private curRecCount As Integer
    Private rects(,) As Rectangle
    Private isSnakePart(,) As Boolean
    Private snake As Collection
    Private snakeBrush As Brush = New SolidBrush(Color.FromArgb(0, 255, 0))
    Private backBrush As Brush = New SolidBrush(Color.FromArgb(1, 1, 1))
    Private tokenBrush As Brush = New SolidBrush(Color.Red)
    Private curDirection As Direction
    Private buffer As Bitmap
    Private columnCount As Integer
    Private rowCount As Integer
    Private snakePoints As Integer
    Private snakeSpeed As Double
    Private snakeLength As Integer
    Private token As Rectangle

    Private Function xyToRectIndex(ByVal X As Integer, ByVal Y As Integer) As Integer
        Return (Y * (columnCount)) + X
    End Function

    Private Sub rectIndexToXY(ByVal Index As Integer, ByRef X As Integer, ByRef Y As Integer)
        X = Index Mod (columnCount)
        Y = Index \ (columnCount)
    End Sub

    Private Sub initSnake()

        Dim x As Integer
        Dim y As Integer
        Dim i As Integer
        Dim index As Integer
        Dim sSnake As structSnake
        snake = New Collection

        x = ((columnCount) - 10) \ 2
        y = ((rowCount) - 6) \ 2

        Dim snakePosition As Point = New Point(x, y)
        index = xyToRectIndex(x, y)

        For i = 1 To INITIAL_SNAKE_RECT_COUNT
            rectIndexToXY(index + (i - 1), x, y)
            sSnake.rect = rects(x, y)
            sSnake.x = x
            sSnake.y = y
            snake.Add(sSnake)
        Next

        snakeLength = INITIAL_SNAKE_RECT_COUNT
        snakeSpeed = 100
        ss.Items("tssSnakeLength").Text = "Length: " & CStr(snakeLength)
        ss.Items("tssSnakeSpeed").Text = "Speed: " & CStr(snakeSpeed) & "%"

    End Sub

    Private Sub selectRectangles()

        Dim g As Graphics = Graphics.FromImage(My.Resources.back)
        Dim i As Integer
        Dim sSnake As structSnake

        For i = 1 To INITIAL_SNAKE_RECT_COUNT
            sSnake = snake(i)
            g.FillRectangle(snakeBrush, sSnake.rect)
            isSnakePart(sSnake.x, sSnake.y) = True
        Next

        buffer = New Bitmap(My.Resources.back)

        g.Dispose()
        Refresh()

    End Sub

    Private Sub initRectangles()

        Dim i As Integer
        Dim j As Integer

        columnCount = COLUMN_COUNT
        rowCount = ROW_COUNT

        ReDim rects(columnCount, rowCount)
        ReDim isSnakePart(columnCount, rowCount)

        For j = 0 To rowCount
            For i = 0 To columnCount
                rects(i, j) = New Rectangle((i * 10) + 1, (j * 10) + 1, 9, 9)
                isSnakePart(i, j) = False
            Next
        Next

        ss.Items("tss0").Text = "Screen Size: " & CStr(columnCount) & " X " & CStr(rowCount)

    End Sub

    Private Sub initialize()

        curRecCount = INITIAL_SNAKE_RECT_COUNT
        curDirection = Direction.Leftward
        snakePoints = 0
        initRectangles()
        initSnake()
        selectRectangles()
        setToken()
        setPoints()
        tmr.Interval = 50
        tmr.Enabled = True

    End Sub

    Private Sub setPoints()
        ss.Items("tss3").Text = "Total Points: " & CStr(snakePoints)
    End Sub

    Private Sub setToken()

        Randomize()
        Dim x As Integer
        Dim y As Integer
        Dim g As Graphics = Graphics.FromImage(buffer)

        x = CInt(Rnd() * columnCount)
        Do While x > columnCount Or isSnakePart(x, y) = True
            x = CInt(Rnd() * columnCount)
        Loop

        y = CInt(Rnd() * rowCount)
        Do While y > rowCount Or isSnakePart(x, y) = True
            y = CInt(Rnd() * rowCount)
        Loop

        token = rects(x, y)
        ss.Items("tss1").Text = "Token Location: ( " & CStr(x) & " , " & CStr(y) & " )"

        g.FillEllipse(tokenBrush, token)
        Refresh()
        g.Dispose()

    End Sub

    Private Sub main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        initialize()
    End Sub

    Private Sub main_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Down
                If Not (curDirection = Direction.Downward Or curDirection = Direction.Upward) Then
                    curDirection = Direction.Downward
                End If
            Case Keys.Left
                If Not (curDirection = Direction.Leftward Or curDirection = Direction.Rightward) Then
                    curDirection = Direction.Leftward
                End If
            Case Keys.Right
                If Not (curDirection = Direction.Rightward Or curDirection = Direction.Leftward) Then
                    curDirection = Direction.Rightward
                End If
            Case Keys.Up
                If Not (curDirection = Direction.Upward Or curDirection = Direction.Downward) Then
                    curDirection = Direction.Upward
                End If
        End Select

    End Sub

    Private Sub moveSnake()

        Dim sSnake As structSnake
        Dim x As Integer
        Dim y As Integer
        Dim rect As Rectangle = New Rectangle()
        Dim g As Graphics = Graphics.FromImage(buffer)

        tmr.Enabled = False


        sSnake = snake(snake.Count)
        g.FillRectangle(backBrush, sSnake.rect)
        snake.Remove(snake.Count)
        isSnakePart(sSnake.x, sSnake.y) = False


        sSnake = snake.Item(1)

        x = sSnake.x
        y = sSnake.y

        Select Case curDirection
            Case Direction.Downward
                y = y + 1
                If y > rowCount Then y = 0
            Case Direction.Leftward
                x = x - 1
                If x < 0 Then x = columnCount
            Case Direction.Rightward
                x = x + 1
                If x > columnCount Then x = 0
            Case Direction.Upward
                y = y - 1
                If y < 0 Then y = rowCount
        End Select

        If isSnakePart(x, y) = True Then
            tmr.Enabled = False

            If MessageBox.Show("Ouch!", "Snake", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                initialize()
                Exit Sub
            Else
                end
            End If

        End If

        ss.Items("tss2").Text = "Snake Location: ( " & CStr(x) & " , " & CStr(y) & " )"

        rect = rects(x, y)

        sSnake.x = x
        sSnake.y = y
        sSnake.rect = rect
        isSnakePart(x, y) = True

        g.FillRectangle(snakeBrush, sSnake.rect)
        Me.BackgroundImage = buffer


        snake.Add(sSnake, , 1)

        If rects(x, y).Equals(CObj(token)) Then

            snakePoints += 1
            setPoints()

            If snakePoints Mod 5 = 0 Then
                sSnake = snake.Item(snake.Count)
                Select Case curDirection
                    Case Direction.Downward
                        sSnake.y -= 1
                    Case (Direction.Leftward)
                        sSnake.x += 1
                    Case Direction.Rightward
                        sSnake.x -= 1
                    Case Direction.Upward
                        sSnake.y += 1
                End Select

                sSnake.rect = rects(sSnake.x, sSnake.y)
                g.FillRectangle(snakeBrush, sSnake.rect)
                Me.BackgroundImage = buffer
                snake.Add(sSnake, , , snake.Count)
                snakeLength = snake.Count

                tmr.Interval -= 2
                If tmr.Interval < 0 Then tmr.Interval = 1

                snakeSpeed = 100 + (((50 - tmr.Interval) / 50) * 100)
                ss.Items("tssSnakeLength").Text = "Length: " & CStr(snakeLength)
                ss.Items("tssSnakeSpeed").Text = "Speed: " & CStr(snakeSpeed) & "%"

            End If

            setToken()

        End If

        Refresh()

        tmr.Enabled = True

    End Sub

    Private Sub tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr.Tick
        moveSnake()
        Application.DoEvents()
    End Sub
End Class
