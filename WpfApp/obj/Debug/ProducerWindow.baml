   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   A =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Rabalski.HeadphoneCatalog.WpfApp.ViewModels+Rabalski.HeadphoneCatalog.WpfApp.ViewModels 5   	   5   /Rabalski.HeadphoneCatalog.WpfApp.ProducerWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   P
viewmodels9clr-namespace:Rabalski.HeadphoneCatalog.WpfApp.ViewModels     5   	   -   5        $��producerWindow��5	   9     � Title$  ProducerWindow��6	   $	��350��6    $	��600��6-    � DataContext 5
      G  ARabalski.HeadphoneCatalog.WpfApp.ViewModels.ProducerListViewModel  5   
    � 	Resources 5         TextBoxWithErrors �� Property �� Value �� DisplayMemberPath �� ElementName �� Path �� Triggers	 P� Property
 P� Value��%�  &	        �� 5   
   .�5      ��  �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� $��Bottom=�6&   $ ErrorContent��6�   ��6>   �� $ ErrorComponent��$( "AdornedElement.(Validation.Errors)�6�   � 5      $
��Left=�6#   .+�5   "   A� $��20��6*   $��20��65   
���  ��
���  ��6c   �� 5   "   
���������6(   �� $ ErrorComponent��$. (AdornedElement.(Validation.Errors).Count�6�   5      �� 5      
���  ��$��2q�6;   ._�5   "   �� $��ErrorComponent��6<   5      5      5      5      �� 5       � ��$	 150��61    5       P� 5!      	 �@=�HasError
 . . �5"      ��  � ��$ 	20 2 2 50q�67   5#      5%      5&      .��5(      ]� ��. .+�5)   
   �� -   5        $��ProducerListPanel��5)   (   $
��Left=�6   $
 Name��6c   ��6A   �� *	Producers+ �� SelectedItem 6|   �� *SelectedProducer+5*      �� 5+   
   $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   .+�5,      �� ��6   �� *FilterDataCommand+.��6;   Filter6C   �� 5-      $	��100��6   ��6%   �� *FilterValue+6E   �� 5.      ��6   �� *AddNewProducerCommand+.��6?   Add new Producer6Q   �� 5/      ��6   �� *SaveProducerCommand+.��6>   Save Producer6M   50      � 51   
   -   5        $��ProdDetailsList��51       6&   �� *EditedProducer+ � RowDefinitions 52      �� 53      $
��Auto �6    �� 54      $��* �6    .+�56      � $��0��6    � ColumnDefinitions 57      �� 58      $
��Auto �6'   66   �� 59      $��* �6'   63    5;      �� 5<      6&   �� 5=      6&   .+�5?      �� $��0��6   .��6%   Name:6,   �� 5@      #��[  6   $��0��6F   $��1��6S   $	��150��6c   ��6r   �� *Name+�� 5A      $��1��6   .��6%   
Country:6/   �� 5B      #��[  6   $��1��6F   $��1��6S   $	��150��6c   ��6r   �� *	Country+5C      5D      5E      5F      