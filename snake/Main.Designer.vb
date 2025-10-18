<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form


    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmr = New System.Windows.Forms.Timer(Me.components)
        Me.ss = New System.Windows.Forms.StatusStrip()
        Me.tss1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss0 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssSnakeLength = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssSnakeSpeed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ss.SuspendLayout()
        Me.SuspendLayout()

        Me.tmr.Enabled = True
        Me.tmr.Interval = 50

        Me.ss.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss0, Me.tss1, Me.tss2, Me.tssSnakeLength, Me.tssSnakeSpeed, Me.tss3})
        Me.ss.Location = New System.Drawing.Point(0, 481)
        Me.ss.Name = "ss"
        Me.ss.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ss.Size = New System.Drawing.Size(661, 22)
        Me.ss.TabIndex = 0
        Me.ss.Text = "StatusStrip1"

        Me.tss1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tss1.Name = "tss1"
        Me.tss1.Size = New System.Drawing.Size(83, 17)
        Me.tss1.Text = "Token Location:"
        Me.tss1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        Me.tss0.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tss0.Name = "tss0"
        Me.tss0.Size = New System.Drawing.Size(66, 17)
        Me.tss0.Text = "Screen Size:"
        Me.tss0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        Me.tss2.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.tss2.Name = "tss2"
        Me.tss2.Size = New System.Drawing.Size(83, 17)
        Me.tss2.Text = "Snake Location:"
        Me.tss2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        Me.tss3.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.tss3.Name = "tss3"
        Me.tss3.Size = New System.Drawing.Size(234, 17)
        Me.tss3.Spring = True
        Me.tss3.Text = "Total Points:"
        Me.tss3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        Me.tssSnakeLength.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.tssSnakeLength.Name = "tssSnakeLength"
        Me.tssSnakeLength.Size = New System.Drawing.Size(76, 17)
        Me.tssSnakeLength.Text = "Snake Length:"
        Me.tssSnakeLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        Me.tssSnakeSpeed.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.tssSnakeSpeed.Name = "tssSnakeSpeed"
        Me.tssSnakeSpeed.Size = New System.Drawing.Size(73, 17)
        Me.tssSnakeSpeed.Text = "Snake Speed:"
        Me.tssSnakeSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.snake.My.Resources.Resources.back
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(661, 503)
        Me.Controls.Add(Me.ss)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(669, 537)
        Me.MinimumSize = New System.Drawing.Size(669, 537)
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Snake"
        Me.ss.ResumeLayout(False)
        Me.ss.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmr As System.Windows.Forms.Timer
    Friend WithEvents ss As System.Windows.Forms.StatusStrip
    Friend WithEvents tss1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tss0 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tss2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tss3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssSnakeLength As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tssSnakeSpeed As System.Windows.Forms.ToolStripStatusLabel

End Class
