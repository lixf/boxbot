package com.boxbot.android;
import java.util.ArrayList;
import java.util.List;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.view.View;

public class BoxBotView extends View {
	
	private Canvas canvas = new Canvas();
	private int coordXMin = 0;
	private int coordXMax = 0;
	private int coordYMin = 0;
	private int coordYMax = 0;
	private int blockSize = 0;
	private int centerX = 0;
	private int centerY = 0;
	private List<Block> blocks = new ArrayList<Block>();
	
	public BoxBotView(Context context) {
		super(context);
	}
	
	public BoxBotView(Context context, List<Block> blocks) {
		super(context);
		this.blocks = blocks;
	}
	
	@Override
	public void onDraw(Canvas canvas) {
		this.canvas = canvas;
		
		blocks = new ArrayList<Block>();
		Block block = new Block(0,0,0);
		blocks.add(block);
		block = new Block(1,1,0);
		blocks.add(block);
		block = new Block(1,0,1);
		blocks.add(block);
		block = new Block(2,1,1);
		blocks.add(block);
		
		this.drawBlocks();
	}
	
	public void drawBlocks() {
		Paint paint = new Paint();
		paint.setColor(Color.WHITE);
		canvas.drawRect(0, 0, canvas.getWidth(), canvas.getHeight(), paint);
		
		// check if the view scale has to be adjusted
		int[] dimensions = calculateDimensions();
		if (!dimensionsIsEqual(dimensions) || blockSize == 0) {
			int height = canvas.getHeight() - 50;
			int width = canvas.getWidth() - 50;
			
			this.coordXMax = dimensions[0];
			this.coordXMin = dimensions[1];
			this.coordYMax = dimensions[2];
			this.coordYMin = dimensions[3];
			
			int blockWidth = this.coordXMax - this.coordXMin;
			int blockHeight = this.coordYMax - this.coordYMin;			
			
			this.blockSize = Math.min(width/blockWidth, height/blockHeight);
			
			this.centerX = (int)((double)width - (double)blockWidth*(double)this.blockSize + Math.abs(this.coordXMin*this.blockSize));
			this.centerY = (int)((double)height - (double)blockHeight*(double)this.blockSize + Math.abs(this.coordYMin*this.blockSize));		
		}
		
		// loop through the blocks and draw them
		for (Block block : blocks) {
			drawBlock(block);
		}
		
		this.draw(canvas);
	}
	private void drawBlock(Block block) {
		Paint paint = new Paint();
		switch (block.color) {
		case 0:
			paint.setColor(Color.BLACK);
			break;
		case 1:
			paint.setColor(Color.BLUE);
			break;
		case 2:
			paint.setColor(Color.RED);
			break;
		}
		int blockOffsetX = this.centerX + this.blockSize*block.coordX;
		int blockOffsetY = this.centerY + this.blockSize*block.coordY;
		canvas.drawRect(blockOffsetX, blockOffsetY, blockOffsetX + this.blockSize, blockOffsetY + this.blockSize, paint);
	}
	
	private int[] calculateDimensions() {
		int xmin = 0;
		int xmax = 0;
		int ymin = 0;
		int ymax = 0;
		
		for (Block block : blocks) {
			if (block.coordX < xmin) xmin = block.coordX;
			if (block.coordX > xmax) xmax = block.coordX;
			if (block.coordY < ymin) ymin = block.coordY;
			if (block.coordY > ymax) ymax = block.coordY;
		}
		
		int[] dimensions = new int[4];
		dimensions[0] = xmin;
		dimensions[1] = xmax;
		dimensions[2] = ymin;
		dimensions[3] = ymax;
		
		return dimensions;
	}
	private boolean dimensionsIsEqual(int[] dimensions) {
		return 
			dimensions[0] == this.coordXMin && 
			dimensions[1] == this.coordXMax &&
			dimensions[2] == this.coordYMin &&
			dimensions[3] == this.coordYMax;
	}
	
}
