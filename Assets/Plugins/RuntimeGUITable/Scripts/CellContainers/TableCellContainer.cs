﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.EventSystems;

namespace UnityUITable
{

	[ExecuteInEditMode]
	public class TableCellContainer : CellContainer, IDeselectHandler, IPointerClickHandler
	{

		public Image background;
		public Image outline;

		RectTransform _cellRectTransform;
		RectTransform cellRectTransform
		{
			get
			{
				if (_cellRectTransform == null)
					_cellRectTransform = GetComponent<RectTransform>();
				return _cellRectTransform;
			}
		}

		RectTransform _maskRectTransform;
		RectTransform maskRectTransform
		{
			get
			{
				if (_maskRectTransform == null)
					_maskRectTransform = GetComponentInParent<RectMask2D>().GetComponent<RectTransform>();
				return _maskRectTransform;
			}
		}

		protected override void Update()
		{
			if (table == null)
				return;
			base.Update();
			background.color = table.GetRowBGColor(rowIndex);
			outline.color = table.lineColor;
			outline.sprite = table.outlineSprite;
		}

		void IDeselectHandler.OnDeselect(BaseEventData eventData)
		{
			if (!(eventData is AxisEventData))
				table.OnRowDeselected(rowIndex);
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			table.OnRowClicked(rowIndex);
		}
    }

}