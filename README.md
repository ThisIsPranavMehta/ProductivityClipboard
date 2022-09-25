The Application requires the hoteky combination CTRL+C to copy and CTRL+V to paste- these hotkeys can be changed via the KeyLogger.cs module.



The default key combinations in the application are as follows-
- Press the CTRL+C, followed by 

  -0 to 9 for copying the selected text onto the different channels/buckets as visible in the UI

  -M to add the selected text to the Mathematical buffer
  
  -T to make a task out of the selected text. 

- Press the CTRL+V followed by 
  
  -0 to 9 for paste the data present in the corresponding channel/bucket
  
  -M to paste the mathematically computed value for all the numbers present in the mathematical buffer. 
 
 

THE GUI ENABLES THE USER TO 
  
  -SELECT/DESELECT THE APPEND MODE FOR THE 0-9 BUFFERS.
    
    -this would be a realtime change. [If APPEND mode is enabled, the data would be appended at the end of the previous data present in the buffer, *by default the mode is set to overwrite]
  
  
  -DELETE THE TEXT IN ANY BUFFER
  
  -CHANGE THE NAME OF ANY CHANNEL/BUCKET [default name is bucket: i]
  
  -DELETE ANY MATHEMATICAL VALUE 
  
  -MARK ANY TASK AS COMPLETED
  
  -CHANGE THE PRIOIRITY OF A TASK [by default the task is assigned a priority of ->5]
  
  -DELETE ANY TASK
  
ALL THE CHANGES- MADE BY THE GUI AND DATA COPIED OTHERWISE, ARE PERMANENT IN NATURE AND ARE STORED IN A JSON FILE INSIDE THE APPLICATION FOLDER. 
  
  ************The code has several examples of "not the ideal code", as this was coded in a couple of days just as a POC.******************
