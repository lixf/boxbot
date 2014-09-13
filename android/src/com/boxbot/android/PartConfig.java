package com.boxbot.android;

import android.support.v7.app.ActionBarActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

public class PartConfig extends ActionBarActivity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_part_config);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.part_config, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}
	
	/* transfer calls to other pages */
    public void jump_map(View view) {
    	Intent intent = new Intent(this,MapActivity.class);
    	startActivity(intent);
    }
    
    public void jump_friends(View view) {
    	Intent intent = new Intent(this,FriendList.class);
    	startActivity(intent);
    }
    
    public void jump_parts(View view) {
    	Intent intent = new Intent(this,PartConfig.class);
    	startActivity(intent);	
    }
    
    public void jump_settings(View view) {
    	Intent intent = new Intent(this,HomeActivity.class);
    	startActivity(intent);
    }
}
