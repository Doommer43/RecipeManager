   M S B A M L   `   `   `  ����T  PEksamenM2E2017.Opskrifter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EksamenM2E2017.OpskrifterEksamenM2E2017.Opskrifter  5   	   *    $EksamenM2E2017.Opskrifter.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:EksamenM2E2017.Opskrifter     5   	     � Title$  Recipe Manager��5   	   $��380.67��6    $��592.655��60   .��5	      � .+�5
   
   �� $
��Left=�6   $	��351��60   $	��Top=�6=   $	��586��6U   .@�5      �� -   5         ��Name$ 
TabRecipes��5      $��
Opskrifter��6*   .��5      � ���#FEFEFE � ColumnDefinitions 5      �� 5      $
��321* �6+   �� 5      $
��259* �6+   .+�5      �� -   5         ��Name$ ListBoxRecipeList��5      $
��Left=�69   $	��271��6T   $��	10,41,0,0q�6a   $	��Top=�6t   $	��188��6�   5      �� 5      $��Opskrifter:��6   $
��Left=�62   $��	10,10,0,0q�6M   $	��Top=�6`   �� 5      $��Detaljer��6   $
��Left=�61   $	��280��6L   $��
214,32,0,0q�6Y   $	��Top=�6m   $	��356��6�   $��2��6�   .��5      � $
��Left=�6   $	��250��6:   $��0,10,-3.6,-2.4q�6G   $	��Top=�6_   $	��346��6w   .+�5      �� $��Total Price:��6$   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $	��100��6�   $��Right=�6�   �� 5      $��	Personer:��6$   $
��Left=�68   $��	10,36,0,0q�6S   $	��Top=�6f   $	��100��6~   $��Right=�6�   �� 5      $��Ingredienser:��6$   $
��Left=�6<   $��	10,67,0,0q�6W   $	��Top=�6j   $	��100��6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$$ DtgIngredientsInSelectedRecipe��5   '   $
��Left=�6O   $	��147��6j   $��	10,93,0,0q�6w   $	��Top=�6�   $	��326��6�      
IsReadOnly . 6�   �� 5      -   5         ��Name$ TxtBoxPersons��5   &   $
��Left=�6=   $��23��6X   $��
115,39,0,0q�6d    �� TextWrapping$
 Wrap=�6x   $��TextBox��6�   $	��Top=�6�   $	��221��6�   $��Center=�6�   �� 5      -   5        $ TxtBoxPrice��5   &   $
��Left=�6;   $��24��6V   $��
115,10,0,0q�6b   $
 Wrap=�6v   $��TextBox��6�   $	��Top=�6�   $	��221��6�   $��Center=�6�   5      5      5      5       �� 5!      -   5        $ TabIngredients��5!      $��Ingredienser��6.   .��5"      � ���#FEFEFE 5#      �� 5$      $
��177* �6+   �� 5%      $
��403* �6+   .+�5'        -   5        $ DtgIngredients��5'      $
��Left=�67   $	��269��6R   $��	10,43,0,0q�6_   $	��Top=�6r   $	��229��6�   $��2��6�    . 6�   �� 5(      -   5         ��Name$ LblIngrediens��5(      $��Ingredienser:��63   $
��Left=�6K   $��	10,12,0,0q�6f   $	��Top=�6y   �� 5)      -	   5        $ LblNewIngredient��5)      $��Ny Ingrediens:��66   $
��Left=�6O   $��100.4,53,0,0q�6j   $	��Top=�6�   $��1��6�   �� 5*      -
   5        $ TbxIngredientName��5*      $
��Left=�69   $��23��6T   $��156.4,92,0,0q�6`   $
 Wrap=�6v   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5+      -   5        $ LblIngredientName��5+      $��Navn:��67   $
��Left=�6G   $��100.4,92,0,0q�6b   $	��Top=�6x   $��1��6�   �� 5,      -   5        $ LblIngredientPrice��5,      $��Pris:��68   $
��Left=�6H   $��108.4,123,0,0q�6c   $	��Top=�6z   $��1��6�   �� 5-      -   5        $ LblIngredientType��5-      $��Type:��67   $
��Left=�6G   $��103.4,154,0,0q�6b   $	��Top=�6y   $��1��6�   �� 5.      -   5        $ TbxIngredientPrice��5.      $
��Left=�6:   $��23��6U   $��156.4,123,0,0q�6a   $
 Wrap=�6x   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5/      -   5        	 ��Name$	 CombxIngredientType��5/      $
��Left=�6<   $��156.4,154,0,0q�6W   $	��Top=�6n   $	��120��6�   $��1��6�   �� 50      -   5        
 ��Name$
 BtnCreateNewIngredient��50      $��Opret ny ingrediens��6=   $
��Left=�6[   $��156.4,191,0,0q�6v   $	��Top=�6�   $	��120��6�   $��1��6�   �� 51      -   5        $
 BtnIngredientInfo��51      $��2��68   $
��Info��6L   $
��Left=�6[   $��
146,19,0,0q�6v   $	��Top=�6�   $��75��6�   6�   52      53      �� 54      -   5        $ TabNewRecipe��54      $��Ny Opskrift��6,   .��55      � ���#FEFEFE.+�56      �� $��Navn på opskriften:��6   $
��Left=�6:   $��	10,10,0,0q�6U   $	��Top=�6h   $	��131��6�   $��Right=�6�   �� 57      $��Antal personer:��6   $
��Left=�66   $��	10,41,0,0q�6Q   $	��Top=�6d   $	��131��6|   $��Right=�6�   �� 58      -   5        $ TxtBoxRecipeName��58      $
��Left=�68   $��23��6S   $��
146,14,0,0q�6_   $
 Wrap=�6s   $	��Top=�6�   $	��225��6�   �� 59      -   5        $" TxtBoxCountOfPersonsInRecipe��59      $
��Left=�6D   $��23��6_   $��
146,44,0,0q�6k   $
 Wrap=�6   $	��Top=�6�   $	��225��6�   �� 5:      $��Liste af Ingredienser��6   $
��Left=�6<   $��	10,72,0,0q�6W   $	��Top=�6j   $	��250��6�     5;      -   5        $ DtgAllIngredients��5;      $
��Left=�6:   $	��209��6U   $��
10,103,0,0q�6b   $	��Top=�6v   $	��250��6�    . 6�     5<      -   5        $ DtgItemsInNewRecipe��5<      $
��Left=�6<   $	��179��6W   $��298,103,0,0q�6d   $	��Top=�6y   $	��272��6�    . 6�   �� 5=      -   5        $
 BtnAddNewRecipe��5=      $��Tilføj��66   $
��Left=�6G   $��298,290,0,0q�6b   $	��Top=�6w   $��75��6�   $��22��6�   6�   �� 5>      $��Total Pris:��6   $
��Left=�62   $��378,287,0,0q�6M   $	��Top=�6b   �� 5?      -   5        $ LblTotalPrice��5?      $��0��63   $
��Left=�6?   $��443,287,0,0q�6Z   $	��Top=�6o   $	��127��6�   $��Right=�6�   �� 5@      $��Ingredienser i opskriften��6   $
��Left=�6@   $��
298,72,0,0q�6[   $	��Top=�6o   $	��272��6�   �� 5A      -   5        $
 BtnMoveItemLeft��5A      $��<��66   $
��Left=�6E   $��265,180,0,0q�6`   $	��Top=�6u   $��28��6�    J� RenderTransformOrigin$ 0.519,1.521&�6�   6�   �� 5B      -   5        $
 BtnMoveItemRight��5B      $��>��67   $
��Left=�6F   $��265,204,0,0q�6a   $	��Top=�6v   $��28��6�   6�   5C      5D      5E      5F      5G      