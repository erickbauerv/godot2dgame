using Godot;

public partial class GameManager : Node
{ 	
	public int Score = 0;
	
	public void AddPoint() 
	{
		Score += 1;
		
		Label scoreLabel = GetNode<Label>("ScoreLabel");
		scoreLabel.Text = $"Voce conseguiu!\nVoce coletou {Score} moedas.";
	}
}
